using FinalV4.Data;
using FinalV4.Models;
using FinalV4.services;
using FinalV4.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using Newtonsoft.Json;
using System.Linq;
using NuGet.Packaging;

namespace FinalV4.Controllers
{
	
	public class UserFunctionalityController : Controller
	{

       

        private readonly ICityRepo _cityRepo;
		ApplicationDbContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public List<Flight> flights { get; set; }
        public UserFunctionalityController(ICityRepo cityRepo , ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
		{
			_cityRepo = cityRepo;
			this.db = db;
            _httpContextAccessor = httpContextAccessor;
            
        }

		public IActionResult Search()
		{
			var Names = _cityRepo.GetAllNames();
			ViewBag.Names = Names;
			return View();
		}

		[HttpPost]
		public IActionResult ApplySearch(string FlightType, string Depature_City, string Arrival_City, DateTime Date)
		{

            var All_Com = db.Users.Where(u => u.Fname == null && u.Lname == null).ToList();
            ViewBag.Com = All_Com;
			var Result1 = db.Flights.Include(N => N.DepartureCity).Include(N => N.ArrivalCity).Include(N=>N.Company)
			.Where(f => f.DepartureCity.Name == Depature_City
			&& f.ArrivalCity.Name == Arrival_City
            && f.DateFrom.Date == Date.Date).ToList();
          
             CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(1);
            string myDateTimeString = Date.ToString("yyyy-MM-dd HH:mm:ss");
            string [] arr = { FlightType, Depature_City, Arrival_City, myDateTimeString };
            string myString = string.Join(",", arr);
            Response.Cookies.Append("sara", myString, option);


            ViewBag.FlightOneWay = Result1;
		
			if (FlightType == "Return")
			{
               var Result2 = db.Flights.Include(N => N.DepartureCity).Include(N => N.ArrivalCity).Include(N => N.Company)
               .Where(f => f.DepartureCity.Name == Arrival_City
			   && f.ArrivalCity.Name == Depature_City
               && f.DateFrom.Date > Date.Date).ToList();
        
               ViewBag.FlightTwoWay = Result2;
            }
		    return View();
		}
      /// <summary>
      /// ////////////////////////////////////////////////////////////////////////
      /// </summary>
      /// <param name="Data"></param>
      /// <returns></returns>
		public IActionResult TestAction(  flightsdata Data)
		{
            if (Data.Return!=null&&Data.firstWay!=null) {
                var result = db.Flights.Where(f => f.Id == Data.firstWay).ToList();
                var result2 = db.Flights.Where(f => f.Id == Data.Return).ToList();

                ViewBag.Result3 = result;
                ViewBag.result4 = result2;     //// please check also in the view ..
            }
            else if(Data.firstWay!=null)
            {
                var result = db.Flights.Where(f => f.Id == Data.firstWay).ToList();
                ViewBag.Result3 = result;
            }
			
            return View();
		}
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="Dat"></param>
        /// <returns></returns>
		[HttpPost]
        public IActionResult filter([FromBody] MyData Dat)
        {
            var x = flights;
            List<string> op = Dat.Filter.ToList();
            string cookieName = "sara";
            string cookieValue = Request.Cookies[cookieName];
            string[] myArray = cookieValue.Split(',');
            DateTime myDateTime;
            DateTime.TryParse(myArray[3], out myDateTime);
            if (op.Count != 0)
              
            {
                var Result1 = db.Flights.Include(N => N.DepartureCity).Include(N => N.ArrivalCity).Include(N => N.Company)
                            .Where(f => f.DepartureCity.Name == myArray[1]
                            && f.ArrivalCity.Name == myArray[2] && op.Contains(f.Comp_id)
                              && f.DateFrom.Date == myDateTime.Date).ToList();


                ViewBag.FlightOneWay = Result1;

                if (myArray[0] == "Return")
                {
                    var Result2 = db.Flights.Include(N => N.DepartureCity).Include(N => N.ArrivalCity).Include(N => N.Company)
                    .Where(f => f.DepartureCity.Name == myArray[2]
                    && f.ArrivalCity.Name == myArray[1]
                    && f.DateFrom.Date > myDateTime.Date
                   && op.Contains(f.Comp_id)).ToList();

                    ViewBag.FlightTwoWay = Result2;
                }
              

            }
            else
            {
                var Result1 = db.Flights.Include(N => N.DepartureCity).Include(N => N.ArrivalCity).Include(N => N.Company)
                            .Where(f => f.DepartureCity.Name == myArray[1]
                            && f.ArrivalCity.Name == myArray[2]
                              && f.DateFrom.Date ==myDateTime.Date).ToList();


                ViewBag.FlightOneWay = Result1;

                if (myArray[0] == "Return")
                {
                    var Result2 = db.Flights.Include(N => N.DepartureCity).Include(N => N.ArrivalCity).Include(N => N.Company)
                    .Where(f => f.DepartureCity.Name == myArray[2]
                    && f.ArrivalCity.Name == myArray[1]
                    && f.DateFrom.Date > myDateTime.Date
                  ).ToList();

                    ViewBag.FlightTwoWay = Result2;
                }

            }


            return PartialView("_filterPartialView");
        }

    }
}
