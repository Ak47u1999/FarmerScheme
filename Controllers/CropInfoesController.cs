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
    public class CropInfoesController : ControllerBase
    {
        private readonly FarmerSchemeContext _context;

        public CropInfoesController(FarmerSchemeContext context)
        {
            _context = context;
        }

        // GET: api/CropInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CropInfo>>> GetCropInfo()
        {
            return await _context.CropInfo.ToListAsync();
        }

        // GET: api/CropInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CropInfo>> GetCropInfo(int id)
        {
            var cropInfo = await _context.CropInfo.FindAsync(id);

            if (cropInfo == null)
            {
                return NotFound();
            }

            return cropInfo;
        }

        // PUT: api/CropInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCropInfo(int id, CropInfo cropInfo)
        {
            if (id != cropInfo.CropType)
            {
                return BadRequest();
            }

            _context.Entry(cropInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CropInfoExists(id))
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

        // POST: api/CropInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CropInfo>> PostCropInfo(CropInfo cropInfo)
        {
            _context.CropInfo.Add(cropInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CropInfoExists(cropInfo.CropType))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCropInfo", new { id = cropInfo.CropType }, cropInfo);
        }

        // DELETE: api/CropInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CropInfo>> DeleteCropInfo(int id)
        {
            var cropInfo = await _context.CropInfo.FindAsync(id);
            if (cropInfo == null)
            {
                return NotFound();
            }

            _context.CropInfo.Remove(cropInfo);
            await _context.SaveChangesAsync();

            return cropInfo;
        }

        private bool CropInfoExists(int id)
        {
            return _context.CropInfo.Any(e => e.CropType == id);
        }
    }
}
