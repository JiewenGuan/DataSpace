using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataSpace.Models;
using DataSpace.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataSpace.Attributes;
using Microsoft.AspNetCore.Http;
using System.Drawing.Printing;

namespace DataSpace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SpaceContext _context;
        private int PersonID => HttpContext.Session.GetInt32(nameof(Person.PersonID)).Value;
        public HomeController(ILogger<HomeController> logger, SpaceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var experiments = _context.Experiments.Include(e => e.Author).Include(e => e.LeadIstitution).Include(e => e.Mission);
            return View(experiments.Where(p => p.EvaluationStatus == EvaluationStatus.Approved).ToList());
        }

        // GET: Experiments/Create
        [AuthorizeUser]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Experiments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AuthorizeUser]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExperimentID,DateOfSubmission,EvaluationStatus,AuthorId,Title,TOA,Aim,Objective,Summary,ModuleDrawing,Status,ExperimentDate,FeildOfResearch,SocialEconomicObjective,LeadInstitutionID,MissionID")] Experiment experiment)
        {
            experiment.DateOfSubmission = DateTime.Now;
            experiment.EvaluationStatus = EvaluationStatus.Preparing;
            experiment.AuthorId = PersonID;
            experiment.LeadInstitutionID = "00 000 000 000";
            experiment.MissionID = 1;

            if (ModelState.IsValid)
            {
                _context.Add(experiment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit), new { id = experiment.ExperimentID });
            }
            return View(experiment);
        }
        [AuthorizeUser]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var experiment = await _context.Experiments.FindAsync(id);
            if (experiment == null || experiment.AuthorId != PersonID)
            {
                return NotFound();
            }
            ViewData["LeadInstitutionID"] = new SelectList(_context.Institutions, "ABN", "Name", experiment.LeadInstitutionID);
            ViewData["MissionID"] = new SelectList(_context.Missions, "MissionID", "Name", experiment.MissionID);
            return View(experiment);
        }
        [HttpPost]
        [AuthorizeUser]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExperimentID,DateOfSubmission,EvaluationStatus,Title,AuthorId,TOA,Aim,Objective,Summary,ModuleDrawing,Status,ExperimentDate,FeildOfResearch,SocialEconomicObjective,LeadInstitutionID,MissionID")] Experiment experiment)
        {
            if (id != experiment.ExperimentID)
            {
                return NotFound();
            }
            var oldExp = await _context.Experiments.FindAsync(id);

            if (experiment.MissionID == 1)
                ModelState.AddModelError(nameof(experiment.MissionID), "Select a Mission");
            if (experiment.LeadInstitutionID == "00 000 000 000")
                ModelState.AddModelError(nameof(experiment.LeadInstitutionID), "Select a Institution");
            if (experiment.AuthorId != oldExp.AuthorId)
                ModelState.AddModelError(nameof(experiment.LeadInstitutionID), "You can not change hidden fields");
            if (experiment.EvaluationStatus != oldExp.EvaluationStatus)
                ModelState.AddModelError(nameof(experiment.LeadInstitutionID), "You can not change hidden fields");
            if (experiment.DateOfSubmission != oldExp.DateOfSubmission)
                ModelState.AddModelError(nameof(experiment.LeadInstitutionID), "You can not change hidden fields");

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
            ViewData["LeadInstitutionID"] = new SelectList(_context.Institutions, "ABN", "Name", experiment.LeadInstitutionID);
            ViewData["MissionID"] = new SelectList(_context.Missions, "MissionID", "Name", experiment.MissionID);
            return View(experiment);
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiment = await _context.Experiments
                .Include(e => e.Author)
                .Include(e => e.LeadIstitution)
                .Include(e => e.Mission)
                .FirstOrDefaultAsync(m => m.ExperimentID == id);
            if (experiment == null)
            {
                return NotFound();
            }

            return View(experiment);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult StatusCode(int? code = null)
        {
            return View(code);
        }
        public IActionResult Success(string message)
        {
            ViewData["Message"] = message;
            return View();
        }

        private bool ExperimentExists(int id)
        {
            return _context.Experiments.Any(e => e.ExperimentID == id);
        }

    }
}
