using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSpace.Data;
using DataSpace.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DataSpace.Controllers
{
    [DataSpace.Attributes.AuthorizeUser]
    public class UserController : Controller
    {
        private readonly SpaceContext _context;
        public UserController(SpaceContext context) => _context = context;
        private int PersonID => HttpContext.Session.GetInt32(nameof(Person.PersonID)).Value;

        public IActionResult Index()
        {
            var experiments = _context.Experiments.Include(e => e.Author).Include(e => e.LeadIstitution).Include(e => e.Mission);
            return View(experiments.Where(p => p.AuthorId == PersonID).OrderBy(p=>p.EvaluationStatus).ToList());
        }
        public async Task<IActionResult> Profile()
        {
            var person = await _context.People.FindAsync(PersonID);
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "ABN", "Name", person.InstitutionID);
            return View(person);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile([Bind("FirstName,FamilyName,Affiliation,City,State,Country,Email,InstitutionID")] Person input)
        {
            if (ModelState.IsValid)
            {
                Person person = await _context.People.FirstOrDefaultAsync(p => p.PersonID == PersonID);
                person.FirstName = input.FirstName;
                person.FamilyName = input.FamilyName;
                person.Affiliation = input.Affiliation;
                person.City = input.City;
                person.State = input.State;
                person.Country = input.Country;
                person.Email = input.Email;
                person.InstitutionID = input.InstitutionID;

                _context.Update(person);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetInt32(nameof(Person.PersonID), person.PersonID);
                HttpContext.Session.SetString(nameof(Person.FirstName), person.FirstName);
                if (person.IsAdmin)
                    HttpContext.Session.SetString(nameof(Person.FamilyName), person.FamilyName);

                return RedirectToAction(nameof(HomeController.Success), "Home", new { message = "Update profile" });
            }
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "ABN", "Name", input.InstitutionID);
            return View(input);
        }

        public IActionResult Password() => View();

        public IActionResult Password(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
                ModelState.AddModelError(nameof(password), "Password too short.");
            if (string.IsNullOrEmpty(password) || password.Length > 50)
                ModelState.AddModelError(nameof(password), "Password too Long.");
            if (!ModelState.IsValid)
                return View();
            _context.Logins.First(x => x.PersonID == PersonID).NewPassword(password);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(HomeController.Success), "Home", new { message = "Update Password" });
        }


    }
}