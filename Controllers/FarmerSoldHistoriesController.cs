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
    public class FarmerSoldHistoriesController : ControllerBase
    {
        private readonly FarmerSchemeContext _context;

        public FarmerSoldHistoriesController(FarmerSchemeContext context)
        {
            _context = context;
        }

        // GET: api/FarmerSoldHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FarmerSoldHistory>>> GetFarmerSoldHistory()
        {
            return await _context.FarmerSoldHistory.ToListAsync();
        }

        // GET: api/FarmerSoldHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FarmerSoldHistory>> GetFarmerSoldHistory(int id)
        {
            var farmerSoldHistory = await _context.FarmerSoldHistory.FindAsync(id);

            if (farmerSoldHistory == null)
            {
                return NotFound();
            }

            return farmerSoldHistory;
        }

        // PUT: api/FarmerSoldHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmerSoldHistory(int id, FarmerSoldHistory farmerSoldHistory)
        {
            if (id != farmerSoldHistory.FarmerId)
            {
                return BadRequest();
            }

            _context.Entry(farmerSoldHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerSoldHistoryExists(id))
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

        // POST: api/FarmerSoldHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FarmerSoldHistory>> PostFarmerSoldHistory(FarmerSoldHistory farmerSoldHistory)
        {
            _context.FarmerSoldHistory.Add(farmerSoldHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FarmerSoldHistoryExists(farmerSoldHistory.FarmerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFarmerSoldHistory", new { id = farmerSoldHistory.FarmerId }, farmerSoldHistory);
        }

        // DELETE: api/FarmerSoldHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FarmerSoldHistory>> DeleteFarmerSoldHistory(int id)
        {
            var farmerSoldHistory = await _context.FarmerSoldHistory.FindAsync(id);
            if (farmerSoldHistory == null)
            {
                return NotFound();
            }

            _context.FarmerSoldHistory.Remove(farmerSoldHistory);
            await _context.SaveChangesAsync();

            return farmerSoldHistory;
        }

        private bool FarmerSoldHistoryExists(int id)
        {
            return _context.FarmerSoldHistory.Any(e => e.FarmerId == id);
        }
    }
}
