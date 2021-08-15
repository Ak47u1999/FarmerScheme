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
    public class MarketplaceTransactionsController : ControllerBase
    {
        private readonly FarmerSchemeContext _context;

        public MarketplaceTransactionsController(FarmerSchemeContext context)
        {
            _context = context;
        }

        // GET: api/MarketplaceTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketplaceTransactions>>> GetMarketplaceTransactions()
        {
            return await _context.MarketplaceTransactions.ToListAsync();
        }

        // GET: api/MarketplaceTransactions/5
        [HttpGet("{id}")]
        public int GetMarketplaceTransactions(int id)
        {
            var approve = _context.MarketplaceTransactions.Where(x => x.TransactionId== id);

            foreach (var i in approve)
            {
                i.BidAdminApprovalStatus = true;
            }
            return _context.SaveChanges();
        }

        // PUT: api/MarketplaceTransactions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketplaceTransactions(int id, MarketplaceTransactions marketplaceTransactions)
        {
            if (id != marketplaceTransactions.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(marketplaceTransactions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketplaceTransactionsExists(id))
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

        // POST: api/MarketplaceTransactions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketplaceTransactions>> PostMarketplaceTransactions(MarketplaceTransactions marketplaceTransactions)
        {
            _context.MarketplaceTransactions.Add(marketplaceTransactions);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MarketplaceTransactionsExists(marketplaceTransactions.TransactionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMarketplaceTransactions", new { id = marketplaceTransactions.TransactionId }, marketplaceTransactions);
        }

        // DELETE: api/MarketplaceTransactions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketplaceTransactions>> DeleteMarketplaceTransactions(int id)
        {
            var marketplaceTransactions = await _context.MarketplaceTransactions.FindAsync(id);
            if (marketplaceTransactions == null)
            {
                return NotFound();
            }

            _context.MarketplaceTransactions.Remove(marketplaceTransactions);
            await _context.SaveChangesAsync();

            return marketplaceTransactions;
        }

        private bool MarketplaceTransactionsExists(int id)
        {
            return _context.MarketplaceTransactions.Any(e => e.TransactionId == id);
        }
    }
}
