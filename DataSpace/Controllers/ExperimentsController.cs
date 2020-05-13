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
    public class ExperimentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExperimentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Experiments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Experiments.Include(e => e.LeadIstitution).Include(e => e.Mission);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Experiments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiment = await _context.Experiments
                .Include(e => e.LeadIstitution)
                .Include(e => e.Mission)
                .FirstOrDefaultAsync(m => m.ExperimentID == id);
            if (experiment == null)
            {
                return NotFound();
            }

            return View(experiment);
        }

        // GET: Experiments/Create
        public IActionResult Create()
        {
            ViewData["LeadInstitutionID"] = new SelectList(_context.Institutions, "ABN", "ABN");
            ViewData["MissionID"] = new SelectList(_context.Missions, "MissionID", "Name");
            return View();
        }

        // POST: Experiments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExperimentID,DateOfSubmission,Title,TOA,Aim,Objective,Summary,ModuleDrawing,Status,EvaluationStatus,ExperimentDate,FeildOfResearch,SocialEconomicObjective,LeadInstitutionID,MissionID")] Experiment experiment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experiment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeadInstitutionID"] = new SelectList(_context.Institutions, "ABN", "ABN", experiment.LeadInstitutionID);
            ViewData["MissionID"] = new SelectList(_context.Missions, "MissionID", "Name", experiment.MissionID);
            return View(experiment);
        }

        // GET: Experiments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiment = await _context.Experiments.FindAsync(id);
            if (experiment == null)
            {
                return NotFound();
            }
            ViewData["LeadInstitutionID"] = new SelectList(_context.Institutions, "ABN", "ABN", experiment.LeadInstitutionID);
            ViewData["MissionID"] = new SelectList(_context.Missions, "MissionID", "Name", experiment.MissionID);
            return View(experiment);
        }

        // POST: Experiments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExperimentID,DateOfSubmission,Title,TOA,Aim,Objective,Summary,ModuleDrawing,Status,EvaluationStatus,ExperimentDate,FeildOfResearch,SocialEconomicObjective,LeadInstitutionID,MissionID")] Experiment experiment)
        {
            if (id != experiment.ExperimentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperimentExists(experiment.ExperimentID))
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
            ViewData["LeadInstitutionID"] = new SelectList(_context.Institutions, "ABN", "ABN", experiment.LeadInstitutionID);
            ViewData["MissionID"] = new SelectList(_context.Missions, "MissionID", "Name", experiment.MissionID);
            return View(experiment);
        }

        // GET: Experiments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiment = await _context.Experiments
                .Include(e => e.LeadIstitution)
                .Include(e => e.Mission)
                .FirstOrDefaultAsync(m => m.ExperimentID == id);
            if (experiment == null)
            {
                return NotFound();
            }

            return View(experiment);
        }

        // POST: Experiments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experiment = await _context.Experiments.FindAsync(id);
            _context.Experiments.Remove(experiment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperimentExists(int id)
        {
            return _context.Experiments.Any(e => e.ExperimentID == id);
        }
    }
}
