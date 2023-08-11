using Microsoft.AspNetCore.Mvc;
using mqtt_dynsec_manager.DynSec.Commands;
using mqtt_dynsec_manager.DynSec.Commands.Abstract;
using mqtt_dynsec_manager.DynSec.Commands.Helpers;
using mqtt_dynsec_manager.DynSec.Interfaces;
using mqtt_dynsec_manager.DynSec.Responses;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;
using mqtt_dynsec_manager.DynSec.Responses.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mqtt_dynsec_manager.Controllers.DynamicSecurity
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IDynSec dynSec;

        public ClientsController(IDynSec _dynSec) { dynSec = _dynSec; }

        // GET: api/<MQTTdynsecController>/clients
        [HttpGet("clients")]
        public async Task<ActionResult<ClientList>> GetClients(bool? verbose)
        {
            var cmd = new ListClients(verbose ?? true);
            var result = await dynSec.ExecuteCommand(cmd);

            if (result is null) return StatusCode(504);
            if (result.Error == "Ok") return Ok(result as ClientList);
            return NotFound(result);
        }

        // GET: api/<MQTTdynsecController>/client/<client>
        [HttpGet("client/{client}")]
        public async Task<ActionResult<ClientInfo>> GetClient(string client)
        {
            var cmd = new GetClient(client);
            var result = await dynSec.ExecuteCommand(cmd);

            if (result is null) return StatusCode(504);
            if (result.Error == "Ok") return Ok(result as ClientInfo);
            return NotFound(result);
        }


 
    }
}
