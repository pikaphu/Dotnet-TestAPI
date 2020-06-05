using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/Test
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            Task.Run(()=>LongRun(id));

            return "value";
        }

        async Task LongRun(string id)
        {
            Console.WriteLine("Start: " + id);

            int i = 0;
            while (true)
            {
                await Task.Delay(1000);

                i++;
                Console.WriteLine(id + " LongRun: " + i);

                if (i >= 10)
                {
                    break;
                }
            }
            Console.WriteLine("END: " + id);
        }

        // POST: api/Test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
