using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapp.Controllers
{
   // [Produces("application/json")]
    [Route("api/TestConfiguration")]
    public class TestConfigurationController : Controller
    {
        // GET: api/TestConfiguration
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { AppConfiguration.ConnectionString, AppConfiguration.Environment, AppConfiguration.Host };
        }

        // GET: api/TestConfiguration/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/TestConfiguration
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/TestConfiguration/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
