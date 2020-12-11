using Genocs.TaskRunner.ExternalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Genocs.TaskRunner.ExternalWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        // GET: api/<DummyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DummyController>/5
        [HttpGet("{id}")]
        public SimpleResult Get(int id)
        {
            return new SimpleResult { MessageId = $"{ id + 1 }" };
        }

        // POST api/<DummyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DummyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DummyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
