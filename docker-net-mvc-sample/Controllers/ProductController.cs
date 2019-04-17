using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace aspnetcoreapp.Controllers
{
 //   [Produces("application/json")]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly HttpClient httpClient;
        // GET: api/Product

        public ProductController()
        {
            httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = new List<KeyValuePair<string, string>>();

            try
            {
                using (HttpResponseMessage response = await this.httpClient.GetAsync("http://webapinetcoremvc:80/api/products"))
                {
                    result = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(await response.Content.ReadAsStringAsync());
                }
            }

            catch (Exception ex)
            {
                var msg = ex.InnerException;
            }
            

            return this.Json(result);
        }

        // GET: api/Product/5
      //  [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Product
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Product/5
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
