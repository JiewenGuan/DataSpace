﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataSpace.Data;
using DataSpace.Models;
using DataSpace.Attributes;

namespace DataSpace.Controllers
{
    [AuthorizeUser]
    public class PeopleController : Controller
    {
        private readonly SpaceContext _context;

        public PeopleController(SpaceContext context)
        {
            _context = context;
        }

        // GET: People
        [AuthorizeAdmin]
        public async Task<IActionResult> Index()
        {
            var spaceContext = _context.People.Include(p => p.Institution);
            return View(await spaceContext.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.Institution)
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "ABN", "Name");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,FirstName,FamilyName,Affiliation,IsAdmin,City,State,Country,Email,InstitutionID,DateOfSubmission,EvaluationStatus")] Person person)
        {
            person.IsAdmin = false;
            person.DateOfSubmission = DateTime.Now;
            person.EvaluationStatus = EvaluationStatus.Preparing;
            person.InstitutionID = "00 000 000 000";
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit),new { id = person.PersonID });
            }
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "ABN", "Name", person.InstitutionID);
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "ABN", "Name", person.InstitutionID);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonID,FirstName,FamilyName,Affiliation,IsAdmin,City,State,Country,Email,InstitutionID,DateOfSubmission,EvaluationStatus")] Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstitutionID"] = new SelectList(_context.Institutions, "ABN", "ABN", person.InstitutionID);
            return View(person);
        }

        // GET: People/Delete/5
        [AuthorizeAdmin]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.Institution)
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [AuthorizeAdmin]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.People.FindAsync(id);
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.PersonID == id);
        }
    }
}
