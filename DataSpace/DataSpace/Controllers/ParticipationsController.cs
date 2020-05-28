using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataSpace.Data;
using DataSpace.Models;

namespace DataSpace.Controllers
{
    public class ParticipationsController : Controller
    {
        private readonly SpaceContext _context;

        public ParticipationsController(SpaceContext context)
        {
            _context = context;
        }

        // GET: Participations
        public async Task<IActionResult> Index()
        {
            var spaceContext = _context.Participations.Include(p => p.Experiment).Include(p => p.Participant).Include(p => p.Role);
            return View(await spaceContext.ToListAsync());
        }

        // GET: Participations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participations
                .Include(p => p.Experiment)
                .Include(p => p.Participant)
                .Include(p => p.Role)
                .FirstOrDefaultAsync(m => m.ParticipateID == id);
            if (participation == null)
            {
                return NotFound();
            }

            return View(participation);
        }

        // GET: Participations/Create
        public IActionResult Create()
        {
            ViewData["ExperimentID"] = new SelectList(_context.Experiments, "ExperimentID", "Aim");
            ViewData["PersonID"] = new SelectList(_context.People, "PersonID", "Affiliation");
            ViewData["RoleID"] = new SelectList(_context.ExpRoles, "RoleID", "RoleDescription");
            return View();
        }

        // POST: Participations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParticipateID,PersonID,RoleID,ExperimentID")] Participation participation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExperimentID"] = new SelectList(_context.Experiments, "ExperimentID", "Aim", participation.ExperimentID);
            ViewData["PersonID"] = new SelectList(_context.People, "PersonID", "Affiliation", participation.PersonID);
            ViewData["RoleID"] = new SelectList(_context.ExpRoles, "RoleID", "RoleDescription", participation.RoleID);
            return View(participation);
        }

        // GET: Participations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participations.FindAsync(id);
            if (participation == null)
            {
                return NotFound();
            }
            ViewData["ExperimentID"] = new SelectList(_context.Experiments, "ExperimentID", "Aim", participation.ExperimentID);
            ViewData["PersonID"] = new SelectList(_context.People, "PersonID", "Affiliation", participation.PersonID);
            ViewData["RoleID"] = new SelectList(_context.ExpRoles, "RoleID", "RoleDescription", participation.RoleID);
            return View(participation);
        }

        // POST: Participations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParticipateID,PersonID,RoleID,ExperimentID")] Participation participation)
        {
            if (id != participation.ParticipateID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipationExists(participation.ParticipateID))
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
            ViewData["ExperimentID"] = new SelectList(_context.Experiments, "ExperimentID", "Aim", participation.ExperimentID);
            ViewData["PersonID"] = new SelectList(_context.People, "PersonID", "Affiliation", participation.PersonID);
            ViewData["RoleID"] = new SelectList(_context.ExpRoles, "RoleID", "RoleDescription", participation.RoleID);
            return View(participation);
        }

        // GET: Participations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participations
                .Include(p => p.Experiment)
                .Include(p => p.Participant)
                .Include(p => p.Role)
                .FirstOrDefaultAsync(m => m.ParticipateID == id);
            if (participation == null)
            {
                return NotFound();
            }

            return View(participation);
        }

        // POST: Participations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participation = await _context.Participations.FindAsync(id);
            _context.Participations.Remove(participation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipationExists(int id)
        {
            return _context.Participations.Any(e => e.ParticipateID == id);
        }
    }
}
