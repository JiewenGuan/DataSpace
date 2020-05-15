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
    public class ResultDatasetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResultDatasetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResultDatasets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ResultDatasets.Include(r => r.Experiment);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ResultDatasets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultDataset = await _context.ResultDatasets
                .Include(r => r.Experiment)
                .FirstOrDefaultAsync(m => m.DatasetID == id);
            if (resultDataset == null)
            {
                return NotFound();
            }

            return View(resultDataset);
        }

        // GET: ResultDatasets/Create
        public IActionResult Create()
        {
            ViewData["ExperimentID"] = new SelectList(_context.Experiments, "ExperimentID", "Aim");
            return View();
        }

        // POST: ResultDatasets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatasetID,Name,RepoUrl,ExperimentID")] ResultDataset resultDataset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultDataset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExperimentID"] = new SelectList(_context.Experiments, "ExperimentID", "Aim", resultDataset.ExperimentID);
            return View(resultDataset);
        }

        // GET: ResultDatasets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultDataset = await _context.ResultDatasets.FindAsync(id);
            if (resultDataset == null)
            {
                return NotFound();
            }
            ViewData["ExperimentID"] = new SelectList(_context.Experiments, "ExperimentID", "Title", resultDataset.ExperimentID);
            return View(resultDataset);
        }

        // POST: ResultDatasets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DatasetID,Name,RepoUrl,ExperimentID")] ResultDataset resultDataset)
        {
            if (id != resultDataset.DatasetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultDataset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultDatasetExists(resultDataset.DatasetID))
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
            ViewData["ExperimentID"] = new SelectList(_context.Experiments, "ExperimentID", "Aim", resultDataset.ExperimentID);
            return View(resultDataset);
        }

        // GET: ResultDatasets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultDataset = await _context.ResultDatasets
                .Include(r => r.Experiment)
                .FirstOrDefaultAsync(m => m.DatasetID == id);
            if (resultDataset == null)
            {
                return NotFound();
            }

            return View(resultDataset);
        }

        // POST: ResultDatasets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultDataset = await _context.ResultDatasets.FindAsync(id);
            _context.ResultDatasets.Remove(resultDataset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultDatasetExists(int id)
        {
            return _context.ResultDatasets.Any(e => e.DatasetID == id);
        }
    }
}
