using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmerScheme.Models;

namespace FarmerScheme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerIdentitiesController : ControllerBase
    {
        private readonly FarmerSchemeContext _context;

        public FarmerIdentitiesController(FarmerSchemeContext context)
        {
            _context = context;
        }

        // GET: api/FarmerIdentities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FarmerIdentity>>> GetFarmerIdentity()
        {
            return await _context.FarmerIdentity.ToListAsync();
        }

        // GET: api/FarmerIdentities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FarmerIdentity>> GetFarmerIdentity(int id)
        {
            var farmerIdentity = await _context.FarmerIdentity.FindAsync(id);

            if (farmerIdentity == null)
            {
                return NotFound();
            }

            return farmerIdentity;
        }

        // PUT: api/FarmerIdentities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmerIdentity(int id, FarmerIdentity farmerIdentity)
        {
            if (id != farmerIdentity.FarmerId)
            {
                return BadRequest();
            }

            _context.Entry(farmerIdentity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerIdentityExists(id))
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

        // POST: api/FarmerIdentities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FarmerIdentity>> PostFarmerIdentity(FarmerIdentity farmerIdentity)
        {
            _context.FarmerIdentity.Add(farmerIdentity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FarmerIdentityExists(farmerIdentity.FarmerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFarmerIdentity", new { id = farmerIdentity.FarmerId }, farmerIdentity);
        }

        // DELETE: api/FarmerIdentities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FarmerIdentity>> DeleteFarmerIdentity(int id)
        {
            var farmerIdentity = await _context.FarmerIdentity.FindAsync(id);
            if (farmerIdentity == null)
            {
                return NotFound();
            }

            _context.FarmerIdentity.Remove(farmerIdentity);
            await _context.SaveChangesAsync();

            return farmerIdentity;
        }

        private bool FarmerIdentityExists(int id)
        {
            return _context.FarmerIdentity.Any(e => e.FarmerId == id);
        }
    }
}
