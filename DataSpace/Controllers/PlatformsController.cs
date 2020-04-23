﻿using System;
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
    public class PlatformsController : ControllerBase
    {
        private readonly SpaceContext _context;

        public PlatformsController(SpaceContext context)
        {
            _context = context;
        }

        // GET: api/Platforms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Platform>>> GetPlatforms()
        {
            return Strip(await _context.Platforms.ToListAsync());
        }
        private List<Platform> Strip(List<Platform> list)
        {
            var ret = new List<Platform>();
            foreach (Platform e in list)
                ret.Add(e.Strip());
            return ret;
        }

        // GET: api/Platforms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Platform>> GetPlatform(int id)
        {
            var platform = await _context.Platforms.FindAsync(id);

            if (platform == null)
            {
                return NotFound();
            }

            return platform.Strip();
        }

        // PUT: api/Platforms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatform(int id, Platform platform)
        {
            if (id != platform.PlatformID)
            {
                return BadRequest();
            }

            _context.Entry(platform).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatformExists(id))
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

        // POST: api/Platforms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Platform>> PostPlatform(Platform platform)
        {
            _context.Platforms.Add(platform);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlatform", new { id = platform.PlatformID }, platform);
        }

        // DELETE: api/Platforms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Platform>> DeletePlatform(int id)
        {
            var platform = await _context.Platforms.FindAsync(id);
            if (platform == null)
            {
                return NotFound();
            }

            _context.Platforms.Remove(platform);
            await _context.SaveChangesAsync();

            return platform.Strip();
        }

        private bool PlatformExists(int id)
        {
            return _context.Platforms.Any(e => e.PlatformID == id);
        }
    }
}
