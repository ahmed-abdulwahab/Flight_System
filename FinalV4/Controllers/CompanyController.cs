using FinalV4.Models;
using FinalV4.services;
using FinalV4.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Mail;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinalV4.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        IUserRepo userRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        public CompanyController(UserManager<ApplicationUser> userManager,IUserRepo userrepo)
        {
            userRepo=userrepo;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            
            
            return View(userRepo.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterCompany(CompanyRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { 
                    UserName = new MailAddress(model.Email).User, 
                    Email = model.Email,
                    PhoneNumber = model.Phone, 
                     Location= model.Location };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Company");

                    // You can redirect to a suitable page after successful registration
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(string id)
        {

            userRepo.RemoveUser(userRepo.Get(id));

            return RedirectToAction("Index");
        }
    }
}
