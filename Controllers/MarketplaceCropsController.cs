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
    public class MarketplaceCropsController : ControllerBase
    {
        private readonly FarmerSchemeContext _context;

        public MarketplaceCropsController(FarmerSchemeContext context)
        {
            _context = context;
        }

        // GET: api/MarketplaceCrops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketplaceCrops>>> GetMarketplaceCrops()
        {
            return await _context.MarketplaceCrops.ToListAsync();
        }

        // GET: api/MarketplaceCrops/5
        [HttpGet("{id}")]
        public int GetMarketplaceCrops(int id)
        {
            var approve = _context.MarketplaceCrops.Where(x => x.RequestId== id);

            foreach (var i in approve)
            {
                i.IsTransactionCompleted = true;
            }
            return _context.SaveChanges();

        }

        // PUT: api/MarketplaceCrops/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketplaceCrops(int id, MarketplaceCrops marketplaceCrops)
        {
            if (id != marketplaceCrops.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(marketplaceCrops).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketplaceCropsExists(id))
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

        // POST: api/MarketplaceCrops
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketplaceCrops>> PostMarketplaceCrops(MarketplaceCrops marketplaceCrops)
        {
            _context.MarketplaceCrops.Add(marketplaceCrops);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MarketplaceCropsExists(marketplaceCrops.RequestId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMarketplaceCrops", new { id = marketplaceCrops.RequestId }, marketplaceCrops);
        }

        // DELETE: api/MarketplaceCrops/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketplaceCrops>> DeleteMarketplaceCrops(int id)
        {
            var marketplaceCrops = await _context.MarketplaceCrops.FindAsync(id);
            if (marketplaceCrops == null)
            {
                return NotFound();
            }

            _context.MarketplaceCrops.Remove(marketplaceCrops);
            await _context.SaveChangesAsync();

            return marketplaceCrops;
        }

        private bool MarketplaceCropsExists(int id)
        {
            return _context.MarketplaceCrops.Any(e => e.RequestId == id);
        }
    }
}
