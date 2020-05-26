using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSpace.Data;
using DataSpace.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataSpace.Controllers
{
    [Route("/Login")]
    public class LoginController : Controller
    {
        private readonly SpaceContext _context;

        public LoginController(SpaceContext context) => _context = context;

        public IActionResult Login() => View();

        private bool Verify(Login login, string password)
        {
            bool ret = login.Verify(password);
            _context.SaveChanges();
            return ret;
        }
        [HttpPost]
        public async Task<IActionResult> Login(string loginID, string password)
        {
            var login = await _context.Logins.FindAsync(loginID);
            if (login == null || !Verify(login, password))
            {
                if (login.BadAttempt < 2)
                    ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
                else
                    ModelState.AddModelError("LoginFailed", "Account Locked!");

                return View(new Login { LoginID = loginID });
            }
            // Login customer.
            HttpContext.Session.SetInt32(nameof(Person.PersonID), login.PersonID);
            HttpContext.Session.SetString(nameof(Person.FirstName), login.Person.FirstName);
            if(login.Person.IsAdmin)
                HttpContext.Session.SetString(nameof(Person.FamilyName), login.Person.FamilyName);

            return RedirectToAction("Index", "Customer");
        }
        [Route("LogoutNow")]
        public IActionResult Logout()
        {
            // Logout customer.
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}