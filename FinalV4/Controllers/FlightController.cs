using FinalV4.Models;
using FinalV4.services;
using FinalV4.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.Mail;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinalV4.Controllers
{
    public class FlightController : Controller
    {
        static int x = 15;
        
        private readonly UserManager<ApplicationUser> _userManager;
        
        IFlightRepo flightRepo;
        ICityRepo cityRepo;
        IUserRepo userRepo;
        public FlightController(IFlightRepo _flightRepo, UserManager<ApplicationUser> userManager,ICityRepo _cityRepo, IUserRepo userRepo)
        {
            flightRepo = _flightRepo;
            _userManager = userManager;
            cityRepo = _cityRepo;
            this.userRepo = userRepo;
        }
        public IActionResult Index()
        {
            string companyId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(flightRepo.GetSpecific(companyId));
        }
        public IActionResult AddFlight()
        {
            
            string companyId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.OriginCities = new SelectList(cityRepo.GetAll(), "Id", "Name");
            ViewBag.DestinationCities = new SelectList(cityRepo.GetAll(), "Id", "Name");

            FlightViewModel model = new FlightViewModel
            {
                CompanyId = companyId
            };

            return View(model);
        }



        [HttpPost]
        public IActionResult AddFlight(FlightViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                string companyId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                Flight newFlight = new Flight
                {
                    Id = ++x,
                    DateFrom = model.DateFrom,
                    Price = model.price,
                    NumberOfSeats=model.NumberOfSeates,
                    ArrivalCityId = model.ArrivalCityId,
                    DepartureCityId=model.DepatureCityId,
                    Comp_id = model.CompanyId
                };

                
                flightRepo.AddFlight(newFlight);
                ViewBag.OriginCities = new SelectList(cityRepo.GetAll(), "Id", "Name", newFlight.DepartureCityId);
                ViewBag.DestinationCities = new SelectList(cityRepo.GetAll(), "Id", "Name", newFlight.ArrivalCityId);



                return RedirectToAction("index", "Flight");
            }

            
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Company")]
        public IActionResult DeleteFlight(int id)
        {
            
            flightRepo.RemoveFlight(flightRepo.GetFlight(id));

            return RedirectToAction("Index");
        }
    }
}
