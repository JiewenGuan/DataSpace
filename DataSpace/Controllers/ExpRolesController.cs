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
    public class ExpRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExpRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpRoles.ToListAsync());
        }

        // GET: ExpRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expRole = await _context.ExpRoles
                .FirstOrDefaultAsync(m => m.RoleID == id);
            if (expRole == null)
            {
                return NotFound();
            }

            return View(expRole);
        }

        // GET: ExpRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleID,Title,RoleDescription")] ExpRole expRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expRole);
        }

        // GET: ExpRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expRole = await _context.ExpRoles.FindAsync(id);
            if (expRole == null)
            {
                return NotFound();
            }
            return View(expRole);
        }

        // POST: ExpRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleID,Title,RoleDescription")] ExpRole expRole)
        {
            if (id != expRole.RoleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpRoleExists(expRole.RoleID))
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
            return View(expRole);
        }

        // GET: ExpRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expRole = await _context.ExpRoles
                .FirstOrDefaultAsync(m => m.RoleID == id);
            if (expRole == null)
            {
                return NotFound();
            }

            return View(expRole);
        }

        // POST: ExpRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expRole = await _context.ExpRoles.FindAsync(id);
            _context.ExpRoles.Remove(expRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpRoleExists(int id)
        {
            return _context.ExpRoles.Any(e => e.RoleID == id);
        }
    }
}
