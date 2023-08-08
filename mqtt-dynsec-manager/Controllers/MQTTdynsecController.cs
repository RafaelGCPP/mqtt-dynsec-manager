using Microsoft.AspNetCore.Mvc;
using mqtt_dynsec_manager.DynSec.Interfaces;
using mqtt_dynsec_manager.DynSec.Responses.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mqtt_dynsec_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MQTTdynsecController : ControllerBase
    {
        private readonly IDynSec dynSec;

        public MQTTdynsecController(IDynSec _dynSec) { dynSec = _dynSec; }

        // GET: api/<MQTTdynsecController>
        [HttpGet("clients")]
        public ResponseList Get()
        {

            return dynSec.Teste();
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
