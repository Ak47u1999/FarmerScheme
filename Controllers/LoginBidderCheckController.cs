using FarmerScheme.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmerScheme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginBidderCheckController : ControllerBase
    {
        public FarmerSchemeContext _context;
        public static int isValid = 0;
        public LoginBidderCheckController(FarmerSchemeContext context)
        {
            _context = context;
        }


        // GET: api/<LoginBidderCheckController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginBidderCheckController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginBidderCheckController>
        [HttpPost]
        public int Post(Loginfieldfarmer loginfieldfarmer)
        {
            var passwordCheck = _context.BidderIdentity.Where(x => x.BidderMailId == loginfieldfarmer.Uname && x.BidderPassword == loginfieldfarmer.Password).FirstOrDefault();
            if (passwordCheck != null)
                isValid = 1;
            else
                isValid = 0;

            return isValid;
        }

        // PUT api/<LoginBidderCheckController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginBidderCheckController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
