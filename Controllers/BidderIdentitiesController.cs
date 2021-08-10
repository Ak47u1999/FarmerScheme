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
    public class BidderIdentitiesController : ControllerBase
    {
        private readonly FarmerSchemeContext _context;

        public BidderIdentitiesController(FarmerSchemeContext context)
        {
            _context = context;
        }

        // GET: api/BidderIdentities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BidderIdentity>>> GetBidderIdentity()
        {
            return await _context.BidderIdentity.ToListAsync();
        }

        // GET: api/BidderIdentities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BidderIdentity>> GetBidderIdentity(int id)
        {
            var bidderIdentity = await _context.BidderIdentity.FindAsync(id);

            if (bidderIdentity == null)
            {
                return NotFound();
            }

            return bidderIdentity;
        }

        // PUT: api/BidderIdentities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBidderIdentity(int id, BidderIdentity bidderIdentity)
        {
            if (id != bidderIdentity.BidderId)
            {
                return BadRequest();
            }

            _context.Entry(bidderIdentity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidderIdentityExists(id))
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

        // POST: api/BidderIdentities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BidderIdentity>> PostBidderIdentity(BidderIdentity bidderIdentity)
        {
            _context.BidderIdentity.Add(bidderIdentity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BidderIdentityExists(bidderIdentity.BidderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBidderIdentity", new { id = bidderIdentity.BidderId }, bidderIdentity);
        }

        // DELETE: api/BidderIdentities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BidderIdentity>> DeleteBidderIdentity(int id)
        {
            var bidderIdentity = await _context.BidderIdentity.FindAsync(id);
            if (bidderIdentity == null)
            {
                return NotFound();
            }

            _context.BidderIdentity.Remove(bidderIdentity);
            await _context.SaveChangesAsync();

            return bidderIdentity;
        }

        private bool BidderIdentityExists(int id)
        {
            return _context.BidderIdentity.Any(e => e.BidderId == id);
        }
    }
}
