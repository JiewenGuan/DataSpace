using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSpace.Attributes;
using DataSpace.Data;
using DataSpace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataSpace.Controllers
{
    [AuthorizeAdmin]
    public class AdminController : Controller
    {
        private readonly SpaceContext _context;
        public AdminController( SpaceContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {            
            return Redirect("/Home/StatusCode/?code=103");

            //var experiments = _context.Experiments.Include(e => e.Author).Include(e => e.LeadIstitution).Include(e => e.Mission);
            //return View(experiments.Where(p => p.EvaluationStatus == EvaluationStatus.Submitted).ToList());
        }
        public IActionResult Review()
        {
            var experiments = _context.Experiments.Include(e => e.Author).Include(e => e.LeadIstitution).Include(e => e.Mission);
            return View(experiments.Where(p => p.EvaluationStatus == EvaluationStatus.Submitted).ToList());

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

        public async Task<IActionResult> Approve(int? id)
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
            experiment.EvaluationStatus = EvaluationStatus.Approved;
            _context.Update(experiment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Review));
        }

        public IActionResult Accounts()
        {
            return Redirect("/Home/StatusCode/?code=103");
        }
    }
}