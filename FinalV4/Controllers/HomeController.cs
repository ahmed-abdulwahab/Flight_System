using FinalV4.Data;
using FinalV4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FinalV4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		ApplicationDbContext db;
		public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
			this.db = db;
		}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
			var All_Com = db.Users.Where(u => u.Fname == null && u.Lname == null).Include(u=>u.Flights) .ToList();
            List<int> counts = new List<int>();
            List<string> Names = new List<string>();
            List<int> Flights = new List<int>();
            foreach (var u in All_Com)
            {
                Names.Add(u.UserName);
                Flights.Add(u.Flights.Count());
            }
            var _Com = db.Users.Count(u => u.Fname == null && u.Lname == null);

			var users = db.Users.Count(u => u.Fname != null && u.Lname != null);
			counts.Add(1);
			counts.Add(users);
            counts.Add(_Com);
			ViewBag.Counts = counts;
			ViewBag.ComNames = Names.ToArray();
            ViewBag.Flights = Flights.ToArray();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}