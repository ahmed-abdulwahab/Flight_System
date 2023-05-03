using FinalV4.Data;
using FinalV4.Models;
using FinalV4.services;
using FinalV4.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Security.Claims;

namespace FinalV4.Controllers
{
    public class BookTicketController : Controller
    {
        private readonly ApplicationDbContext _context;
        IUserRepo _userRepo;

        const string SessionFId = "_flightID";
        const string ObjData = "_ObjData";

        const string oneWayID = "oneWayID";
        const string returnID = "returnID";
        const string selectedbag = "selectedbag";
        const string Gender = "Gender";
        const string birthday = "birthday";
        const string cart = "cart";
        const string seats = "seats";




        public BookTicketController(ApplicationDbContext context, IUserRepo userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }

        public IActionResult Index(flightsdata Data)
        {

            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user1 = _userRepo.Get(userID);
            ViewBag.phone = user1.PhoneNumber;
            ViewBag.email = user1.Email;
            ViewBag.firstname = user1.Fname;
            ViewBag.lastname = user1.Lname;


            var flightId = _context.Flights.Where(f => f.Id == Data.firstWay).Select(f => f.Id).FirstOrDefault();
            //HttpContext.Session.SetInt32(SessionFId, flightId);

            ViewBag.HandBag = StaticMenus.handBaggages.ToList();
            //ViewBag.FoodList = StaticMenus.foodMenuViewModels.ToList();
            if (Data.Return != 0 && Data.firstWay != 0)
            {
                Flight OneWay = _context.Flights
                    .Include(f => f.ArrivalCity)
                    .Include(d => d.DepartureCity)
                    .FirstOrDefault(f => f.Id == Data.firstWay);
                Flight TwoWay = _context.Flights
                    .Include(f => f.ArrivalCity)
                    .Include(d => d.DepartureCity)
                    .FirstOrDefault(f => f.Id == Data.Return);
                // var result2 = _context.Flights.Where(f => f.Id == Data.Return);

                ViewBag.Result3 = OneWay;
                ViewBag.result4 = TwoWay;     //// please check also in the view ..
            }
            else if (Data.firstWay != 0)
            {
                Flight OneWay = _context.Flights
                      .Include(f => f.ArrivalCity)
                      .Include(d => d.DepartureCity).FirstOrDefault(f => f.Id == Data.firstWay);



                ViewBag.Result3 = OneWay;
            }
            return View();
        }



        public ActionResult StepOne(UserDataWithBooking userDataWithBooking)
        {

            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user1 = _userRepo.Get(userID);
            ViewBag.phone = user1.PhoneNumber;
            ViewBag.email = user1.Email;
            ViewBag.firstname = user1.Fname;
            ViewBag.lastname = user1.Lname;



            HttpContext.Session.SetInt32(oneWayID, userDataWithBooking.oneWayID);
            HttpContext.Session.SetInt32(returnID, userDataWithBooking.returnID);
            HttpContext.Session.SetString(Gender, userDataWithBooking.Gender);
            HttpContext.Session.SetString(birthday, userDataWithBooking.birthday);
            HttpContext.Session.SetInt32(selectedbag, userDataWithBooking.selectedbag);

            if (userDataWithBooking.oneWayID != 0 && userDataWithBooking.returnID != 0)
            {
                Flight OneWay = _context.Flights
                    .Include(f => f.ArrivalCity)
                    .Include(d => d.DepartureCity)
                    .FirstOrDefault(f => f.Id == userDataWithBooking.oneWayID);

                Flight TwoWay = _context.Flights
                    .Include(f => f.ArrivalCity)
                    .Include(d => d.DepartureCity)
                    .FirstOrDefault(f => f.Id == userDataWithBooking.returnID);
                // var result2 = _context.Flights.Where(f => f.Id == Data.Return);

                ViewBag.Result5 = OneWay;
                ViewBag.result6 = TwoWay;     //// please check also in the view ..
            }
            else if (userDataWithBooking.oneWayID != 0)
            {
                var OneWay = _context.Flights
                      .Include(f => f.ArrivalCity)
                      .Include(d => d.DepartureCity)
                      .Where(f => f.Id == userDataWithBooking.oneWayID).ToList();

                ViewBag.Result5 = OneWay[0];
            }

            return View();
        }


        public ActionResult StepTwo(UserDataWithBooking userDataWithBooking)
        {

            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user1 = _userRepo.Get(userID);
            ViewBag.phone = user1.PhoneNumber;
            ViewBag.email = user1.Email;
            ViewBag.firstname = user1.Fname;
            ViewBag.lastname = user1.Lname;
            HttpContext.Session.SetInt32(cart, userDataWithBooking.cart);

            
           
            if (userDataWithBooking.oneWayID != 0 && userDataWithBooking.returnID != 0)
            {
                Flight OneWay = _context.Flights
                    .Include(f => f.ArrivalCity)
                    .Include(d => d.DepartureCity)
                    .FirstOrDefault(f => f.Id == userDataWithBooking.oneWayID);

                Flight TwoWay = _context.Flights
                    .Include(f => f.ArrivalCity)
                    .Include(d => d.DepartureCity)
                    .FirstOrDefault(f => f.Id == userDataWithBooking.returnID);
                // var result2 = _context.Flights.Where(f => f.Id == Data.Return);

                ViewBag.Result7 = OneWay;
                ViewBag.Result8 = TwoWay;     //// please check also in the view ..
            }
            else if (userDataWithBooking.oneWayID != 0)
            {

                     Flight OneWay = _context.Flights
                    .Include(f => f.ArrivalCity)
                    .Include(d => d.DepartureCity)
                    .FirstOrDefault(f => f.Id == userDataWithBooking.oneWayID);

                ViewBag.Result7 = OneWay;
            }


            return View();
        }

        [HttpPost]
        public ActionResult StepThree()
        {


            ////int flightID = (int)HttpContext.Session.GetInt32(SessionFId);
            //int OneWayVar = (int)HttpContext.Session.GetInt32(oneWayID);
            //int ReturnVar = (int)HttpContext.Session.GetInt32(returnID);
            //int selectedbagpriceVar = (int)HttpContext.Session.GetInt32(selectedbag);
            //string GenderVar = HttpContext.Session.GetString(Gender);
            //string birthdayVar = HttpContext.Session.GetString(birthday);


            //ViewBag.Gender= HttpContext.Session.GetString(Gender);

            //return RedirectToAction("NewAction", "NewController");
            return View();
        }
        public ActionResult StepFour(UserDataWithBooking userDataWithBooking)
        {
            HttpContext.Session.SetString(seats, userDataWithBooking.seats);


            return RedirectToAction("Create", "Payment");
        }



    }
}
