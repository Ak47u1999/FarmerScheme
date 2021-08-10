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
    public class InsuranceApplicationsController : ControllerBase
    {
        private readonly FarmerSchemeContext _context;

        public InsuranceApplicationsController(FarmerSchemeContext context)
        {
            _context = context;
        }

        // GET: api/InsuranceApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceApplication>>> GetInsuranceApplication()
        {
            return await _context.InsuranceApplication.ToListAsync();
        }

        // GET: api/InsuranceApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceApplication>> GetInsuranceApplication(int id)
        {
            var insuranceApplication = await _context.InsuranceApplication.FindAsync(id);

            if (insuranceApplication == null)
            {
                return NotFound();
            }

            return insuranceApplication;
        }

        // PUT: api/InsuranceApplications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceApplication(int id, InsuranceApplication insuranceApplication)
        {
            if (id != insuranceApplication.PolicyNo)
            {
                return BadRequest();
            }

            _context.Entry(insuranceApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceApplicationExists(id))
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

        // POST: api/InsuranceApplications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InsuranceApplication>> PostInsuranceApplication(InsuranceApplication insuranceApplication)
        {
            _context.InsuranceApplication.Add(insuranceApplication);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InsuranceApplicationExists(insuranceApplication.PolicyNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInsuranceApplication", new { id = insuranceApplication.PolicyNo }, insuranceApplication);
        }

        // DELETE: api/InsuranceApplications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InsuranceApplication>> DeleteInsuranceApplication(int id)
        {
            var insuranceApplication = await _context.InsuranceApplication.FindAsync(id);
            if (insuranceApplication == null)
            {
                return NotFound();
            }

            _context.InsuranceApplication.Remove(insuranceApplication);
            await _context.SaveChangesAsync();

            return insuranceApplication;
        }

        private bool InsuranceApplicationExists(int id)
        {
            return _context.InsuranceApplication.Any(e => e.PolicyNo == id);
        }
    }
}
