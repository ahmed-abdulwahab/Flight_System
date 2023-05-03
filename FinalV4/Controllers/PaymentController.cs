using Microsoft.AspNetCore.Mvc;
using Stripe;
using FinalV4.Models;
using FinalV4.ViewModel;
using System.Security.Claims;
using FinalV4.Data;

namespace Stripe_Payment.Controllers
{
    public class PaymentController : Controller
    {
        ApplicationDbContext _context;
        const string SessionFId = "_flightID";
        const string ObjData = "_ObjData";

        const string oneWayID = "oneWayID";
        const string returnID = "returnID";
        const string selectedbag = "selectedbag";
        const string Gender = "Gender";
        const string birthday = "birthday";
        const string cart = "cart";
        const string seats = "seats";

        public PaymentController(ApplicationDbContext context)
        {
            
                _context = context;
              
            
        }
        // GET: PaymentController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: PaymentController/Create
        [HttpPost]
        public ActionResult Create(string s)
        {
            int total = ((int)HttpContext.Session.GetInt32(selectedbag) + (int)HttpContext.Session.GetInt32(cart));
            BookTicket bookTicket = new BookTicket();
            bookTicket.User_id= User.FindFirstValue(ClaimTypes.NameIdentifier);
            bookTicket.Flight_id = (int)HttpContext.Session.GetInt32(oneWayID);

            var flight = _context.Flights.FirstOrDefault(f => f.Id == bookTicket.Flight_id);

            bookTicket.NumberOfTicket = 1;
            bookTicket.reserve_Seats = (Reserve_seats)Enum.Parse(typeof(Reserve_seats), HttpContext.Session.GetString(seats)) ;
            bookTicket.TotalPrice = total+flight.Price;
            bookTicket.Description = HttpContext.Session.GetString(Gender) +","+ HttpContext.Session.GetString(birthday);
            _context.BookTickets.Add(bookTicket);
            _context.SaveChanges();
           
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = paymentIntentService.Create(new PaymentIntentCreateOptions
            {
                Amount = (long)bookTicket.TotalPrice*100,
                Currency = "usd",
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {

                    Enabled = true,
                },
            });

            return Json(new { clientSecret = paymentIntent.ClientSecret });

        }

        [HttpPost]
        public async Task<IActionResult> Webhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            const string endpointSecret = "whsec_a68f1752b40f41194f7cc91c76233c17f8c6e22c81d4852bf9a388b6509e922d";
            try
            {
                var stripeEvent = EventUtility.ParseEvent(json);
                var signatureHeader = Request.Headers["Stripe-Signature"];

                stripeEvent = EventUtility.ConstructEvent(json,
                        signatureHeader, endpointSecret);

                if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                    Console.WriteLine("A successful payment for {0} was made.", paymentIntent.Amount);
                    // Then define and call a method to handle the successful payment intent.
                    // handlePaymentIntentSucceeded(paymentIntent);
                }
                else if (stripeEvent.Type == Events.PaymentMethodAttached)
                {
                    var paymentMethod = stripeEvent.Data.Object as PaymentMethod;
                    // Then define and call a method to handle the successful attachment of a PaymentMethod.
                    // handlePaymentMethodAttached(paymentMethod);
                }
                else
                {
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }
                return Ok();
            }
            catch (StripeException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
       
    }
}


    

