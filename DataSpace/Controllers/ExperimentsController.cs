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
    public class ExperimentsController : ControllerBase
    {
        private readonly SpaceContext _context;

        public ExperimentsController(SpaceContext context)
        {
            _context = context;
        }

        // GET: api/Experiments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experiment>>> GetExperiments()
        {
            return Strip(await _context.Experiments.ToListAsync());
        }

        private List<Experiment> Strip(List<Experiment> list)
        {
            var ret = new List<Experiment>();
            foreach (Experiment e in list)
                ret.Add(e.Strip());
            return ret;
        }

        // GET: api/Experiments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Experiment>> GetExperiment(int id)
        {
            var experiment = await _context.Experiments.FindAsync(id);

            if (experiment == null)
            {
                return NotFound();
            }

            return experiment.Strip();
        }

        // PUT: api/Experiments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperiment(int id, Experiment experiment)
        {
            if (id != experiment.ExperimentID)
            {
                return BadRequest();
            }

            _context.Entry(experiment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperimentExists(id))
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

        // POST: api/Experiments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Experiment>> PostExperiment(Experiment experiment)
        {
            _context.Experiments.Add(experiment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperiment", new { id = experiment.ExperimentID }, experiment);
        }

        // DELETE: api/Experiments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Experiment>> DeleteExperiment(int id)
        {
            var experiment = await _context.Experiments.FindAsync(id);
            if (experiment == null)
            {
                return NotFound();
            }

            _context.Experiments.Remove(experiment);
            await _context.SaveChangesAsync();

            return experiment.Strip();
        }

        private bool ExperimentExists(int id)
        {
            return _context.Experiments.Any(e => e.ExperimentID == id);
        }
    }
}
