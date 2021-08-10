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
    public class InsuranceClaimsController : ControllerBase
    {
        private readonly FarmerSchemeContext _context;

        public InsuranceClaimsController(FarmerSchemeContext context)
        {
            _context = context;
        }

        // GET: api/InsuranceClaims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceClaim>>> GetInsuranceClaim()
        {
            return await _context.InsuranceClaim.ToListAsync();
        }

        // GET: api/InsuranceClaims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceClaim>> GetInsuranceClaim(int id)
        {
            var insuranceClaim = await _context.InsuranceClaim.FindAsync(id);

            if (insuranceClaim == null)
            {
                return NotFound();
            }

            return insuranceClaim;
        }

        // PUT: api/InsuranceClaims/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceClaim(int id, InsuranceClaim insuranceClaim)
        {
            if (id != insuranceClaim.ClaimId)
            {
                return BadRequest();
            }

            _context.Entry(insuranceClaim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceClaimExists(id))
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

        // POST: api/InsuranceClaims
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InsuranceClaim>> PostInsuranceClaim(InsuranceClaim insuranceClaim)
        {
            _context.InsuranceClaim.Add(insuranceClaim);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InsuranceClaimExists(insuranceClaim.ClaimId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInsuranceClaim", new { id = insuranceClaim.ClaimId }, insuranceClaim);
        }

        // DELETE: api/InsuranceClaims/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InsuranceClaim>> DeleteInsuranceClaim(int id)
        {
            var insuranceClaim = await _context.InsuranceClaim.FindAsync(id);
            if (insuranceClaim == null)
            {
                return NotFound();
            }

            _context.InsuranceClaim.Remove(insuranceClaim);
            await _context.SaveChangesAsync();

            return insuranceClaim;
        }

        private bool InsuranceClaimExists(int id)
        {
            return _context.InsuranceClaim.Any(e => e.ClaimId == id);
        }
    }
}
