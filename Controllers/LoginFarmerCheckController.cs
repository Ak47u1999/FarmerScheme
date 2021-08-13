using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmerScheme.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmerScheme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginFarmerCheckController : ControllerBase
    {
        public FarmerSchemeContext _context;
        public static int isValid=0;
        public LoginFarmerCheckController(FarmerSchemeContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public int Get()
        {
            int returnval = isValid;
            isValid = (isValid == 1) ? 0 : 0;

            return  returnval;
        }

        // GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public int Post(Loginfieldfarmer loginfieldfarmer)
        {
            var passwordCheck = _context.FarmerIdentity.Where(x => x.FarmerMailId == loginfieldfarmer.Uname && x.FarmerPassword == loginfieldfarmer.Password).FirstOrDefault();
            if (passwordCheck != null)
                isValid = 1;
            else
                isValid = 0;

            return isValid;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
