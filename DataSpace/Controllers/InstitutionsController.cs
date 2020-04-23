using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataSpace.Data;
using DataSpace.Models;

namespace DataSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        private readonly SpaceContext _context;

        public InstitutionsController(SpaceContext context)
        {
            _context = context;
        }

        // GET: api/Institutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institution>>> GetInstitutions()
        {
            return Strip(await _context.Institutions.ToListAsync());
        }

        private List<Institution> Strip(List<Institution> list)
        {
            var ret = new List<Institution>();
            foreach (Institution e in list)
                ret.Add(e.Strip());
            return ret;
        }

        // GET: api/Institutions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Institution>> GetInstitution(string id)
        {
            var institution = await _context.Institutions.FindAsync(id);

            if (institution == null)
            {
                return NotFound();
            }

            return institution.Strip();
        }

        // PUT: api/Institutions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitution(string id, Institution institution)
        {
            if (id != institution.ABN)
            {
                return BadRequest();
            }

            _context.Entry(institution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Institutions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Institution>> PostInstitution(Institution institution)
        {
            _context.Institutions.Add(institution);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InstitutionExists(institution.ABN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInstitution", new { id = institution.ABN }, institution);
        }

        // DELETE: api/Institutions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Institution>> DeleteInstitution(string id)
        {
            var institution = await _context.Institutions.FindAsync(id);
            if (institution == null)
            {
                return NotFound();
            }

            _context.Institutions.Remove(institution);
            await _context.SaveChangesAsync();

            return institution.Strip();
        }

        private bool InstitutionExists(string id)
        {
            return _context.Institutions.Any(e => e.ABN == id);
        }
    }
}
