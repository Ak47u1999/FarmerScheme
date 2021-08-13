using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmerScheme.Models;
using Microsoft.Data.SqlClient;

namespace FarmerScheme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginfieldfarmersController : ControllerBase
    {
        private readonly FarmerSchemeContext _context;

        public LoginfieldfarmersController(FarmerSchemeContext context)
        {
            _context = context;
        }

        // GET: api/Loginfieldfarmers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loginfieldfarmer>>> GetLoginfieldfarmer()
        {
            return await _context.Loginfieldfarmer.ToListAsync();
        }

        // GET: api/Loginfieldfarmers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loginfieldfarmer>> GetLoginfieldfarmer(string id)
        {
            var loginfieldfarmer = await _context.Loginfieldfarmer.FindAsync(id);

            if (loginfieldfarmer == null)
            {
                return NotFound();
            }

            return loginfieldfarmer;
        }

        // PUT: api/Loginfieldfarmers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginfieldfarmer(string id, Loginfieldfarmer loginfieldfarmer)
        {
            if (id != loginfieldfarmer.Uname)
            {
                return BadRequest();
            }

            _context.Entry(loginfieldfarmer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginfieldfarmerExists(id))
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

        // POST: api/Loginfieldfarmers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Loginfieldfarmer>> PostLoginfieldfarmer(Loginfieldfarmer loginfieldfarmer)
        {
            _context.Loginfieldfarmer.Add(loginfieldfarmer);

            
            try
            {
                var passwordCheck = _context.Loginfieldfarmer.Where(x => x.Uname == loginfieldfarmer.Uname && x.Password == loginfieldfarmer.Password).FirstOrDefault();
                if (passwordCheck != null)
                {
                    _context.Loginfieldfarmer.Add(loginfieldfarmer);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    if (LoginfieldfarmerExists(loginfieldfarmer.Uname))
                    {
                        return Conflict();
                    }
                }
            }
            catch (DbUpdateException)
            {
                if (LoginfieldfarmerExists(loginfieldfarmer.Uname))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoginfieldfarmer", new { id = loginfieldfarmer.Uname }, loginfieldfarmer);
        }

        // DELETE: api/Loginfieldfarmers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Loginfieldfarmer>> DeleteLoginfieldfarmer(string id)
        {
            var loginfieldfarmer = await _context.Loginfieldfarmer.FindAsync(id);
            if (loginfieldfarmer == null)
            {
                return NotFound();
            }

            _context.Loginfieldfarmer.Remove(loginfieldfarmer);
            await _context.SaveChangesAsync();

            return loginfieldfarmer;
        }

        private bool LoginfieldfarmerExists(string id)
        {
            return _context.Loginfieldfarmer.Any(e => e.Uname == id);
        }
    }
}
