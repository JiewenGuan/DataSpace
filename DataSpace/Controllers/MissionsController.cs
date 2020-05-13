﻿using System;
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
    public class MissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Missions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Missions.Include(m => m.Platform);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Missions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mission = await _context.Missions
                .Include(m => m.Platform)
                .FirstOrDefaultAsync(m => m.MissionID == id);
            if (mission == null)
            {
                return NotFound();
            }

            return View(mission);
        }

        // GET: Missions/Create
        public IActionResult Create()
        {
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "PlatformID", "Name");
            return View();
        }

        // POST: Missions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MissionID,Name,Commancement,Conclusion,PlatformID")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "PlatformID", "Name", mission.PlatformID);
            return View(mission);
        }

        // GET: Missions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mission = await _context.Missions.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "PlatformID", "Name", mission.PlatformID);
            return View(mission);
        }

        // POST: Missions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MissionID,Name,Commancement,Conclusion,PlatformID")] Mission mission)
        {
            if (id != mission.MissionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MissionExists(mission.MissionID))
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
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "PlatformID", "Name", mission.PlatformID);
            return View(mission);
        }

        // GET: Missions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mission = await _context.Missions
                .Include(m => m.Platform)
                .FirstOrDefaultAsync(m => m.MissionID == id);
            if (mission == null)
            {
                return NotFound();
            }

            return View(mission);
        }

        // POST: Missions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mission = await _context.Missions.FindAsync(id);
            _context.Missions.Remove(mission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MissionExists(int id)
        {
            return _context.Missions.Any(e => e.MissionID == id);
        }
    }
}
