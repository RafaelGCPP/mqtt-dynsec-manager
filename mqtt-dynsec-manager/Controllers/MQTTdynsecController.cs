using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mqtt_dynsec_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MQTTdynsecController : ControllerBase
    {
        // GET: api/<MQTTdynsecController>
        [HttpGet("clients")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MQTTdynsecController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MQTTdynsecController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MQTTdynsecController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MQTTdynsecController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
