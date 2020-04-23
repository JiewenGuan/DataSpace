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
    public class ResultDatasetsController : ControllerBase
    {
        private readonly SpaceContext _context;

        public ResultDatasetsController(SpaceContext context)
        {
            _context = context;
        }

        // GET: api/ResultDatasets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultDataset>>> GetResultDatasets()
        {
            return Strip(await _context.ResultDatasets.ToListAsync());
        }
        private List<ResultDataset> Strip(List<ResultDataset> list)
        {
            var ret = new List<ResultDataset>();
            foreach (ResultDataset e in list)
                ret.Add(e.Strip());
            return ret;
        }

        // GET: api/ResultDatasets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultDataset>> GetResultDataset(int id)
        {
            var resultDataset = await _context.ResultDatasets.FindAsync(id);

            if (resultDataset == null)
            {
                return NotFound();
            }

            return resultDataset.Strip();
        }

        // PUT: api/ResultDatasets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResultDataset(int id, ResultDataset resultDataset)
        {
            if (id != resultDataset.DatasetID)
            {
                return BadRequest();
            }

            _context.Entry(resultDataset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultDatasetExists(id))
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

        // POST: api/ResultDatasets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ResultDataset>> PostResultDataset(ResultDataset resultDataset)
        {
            _context.ResultDatasets.Add(resultDataset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResultDataset", new { id = resultDataset.DatasetID }, resultDataset);
        }

        // DELETE: api/ResultDatasets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultDataset>> DeleteResultDataset(int id)
        {
            var resultDataset = await _context.ResultDatasets.FindAsync(id);
            if (resultDataset == null)
            {
                return NotFound();
            }

            _context.ResultDatasets.Remove(resultDataset);
            await _context.SaveChangesAsync();

            return resultDataset.Strip();
        }

        private bool ResultDatasetExists(int id)
        {
            return _context.ResultDatasets.Any(e => e.DatasetID == id);
        }
    }
}
