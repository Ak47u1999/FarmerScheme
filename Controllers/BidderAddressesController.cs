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
    public class BidderAddressesController : ControllerBase
    {
        private readonly FarmerSchemeContext _context;

        public BidderAddressesController(FarmerSchemeContext context)
        {
            _context = context;
        }

        // GET: api/BidderAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BidderAddress>>> GetBidderAddress()
        {
            return await _context.BidderAddress.ToListAsync();
        }

        // GET: api/BidderAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BidderAddress>> GetBidderAddress(int id)
        {
            var bidderAddress = await _context.BidderAddress.FindAsync(id);

            if (bidderAddress == null)
            {
                return NotFound();
            }

            return bidderAddress;
        }

        // PUT: api/BidderAddresses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBidderAddress(int id, BidderAddress bidderAddress)
        {
            if (id != bidderAddress.BidderId)
            {
                return BadRequest();
            }

            _context.Entry(bidderAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidderAddressExists(id))
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

        // POST: api/BidderAddresses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BidderAddress>> PostBidderAddress(BidderAddress bidderAddress)
        {
            _context.BidderAddress.Add(bidderAddress);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BidderAddressExists(bidderAddress.BidderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBidderAddress", new { id = bidderAddress.BidderId }, bidderAddress);
        }

        // DELETE: api/BidderAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BidderAddress>> DeleteBidderAddress(int id)
        {
            var bidderAddress = await _context.BidderAddress.FindAsync(id);
            if (bidderAddress == null)
            {
                return NotFound();
            }

            _context.BidderAddress.Remove(bidderAddress);
            await _context.SaveChangesAsync();

            return bidderAddress;
        }

        private bool BidderAddressExists(int id)
        {
            return _context.BidderAddress.Any(e => e.BidderId == id);
        }
    }
}
