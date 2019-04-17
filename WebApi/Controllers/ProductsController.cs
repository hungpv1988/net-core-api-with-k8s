using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
  //  [Produces("application/json")]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        // GET: api/Products
        [HttpGet]
        public List<KeyValuePair<string, string>> Get()
        {
            return new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>( "1", "Product 01"),
                new KeyValuePair<string, string>( "2", "Product 02"),
                new KeyValuePair<string, string>( "3", "Product 03"),
                new KeyValuePair<string, string>( "4", "Product 04"),
                new KeyValuePair<string, string>( "5", "Product 05"),
                new KeyValuePair<string, string>( "6", "Product 06"),
            };
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Products
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Products/5
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
