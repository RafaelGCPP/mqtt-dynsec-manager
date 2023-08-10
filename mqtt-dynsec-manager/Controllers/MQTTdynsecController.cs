using Microsoft.AspNetCore.Mvc;
using mqtt_dynsec_manager.DynSec.Commands;
using mqtt_dynsec_manager.DynSec.Commands.Abstract;
using mqtt_dynsec_manager.DynSec.Commands.Helpers;
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

        // GET: api/<MQTTdynsecController>/clients
        [HttpGet("clients")]
        public async Task<ResponseList> GetGlients(bool? verbose)
        {
            var cmds = new CommandsList(new List<AbstractCommand> {
                new ListClients(verbose ?? true),
            });

            return await dynSec.ExecuteAsync(TimeSpan.FromSeconds(10), cmds);

        }
        // GET: api/<MQTTdynsecController>/roles
        [HttpGet("roles")]
        public async Task<ResponseList> GetRoles(bool? verbose)
        {
            var cmds = new CommandsList(new List<AbstractCommand> {
                new ListRoles(verbose ?? true),
            });

            return await dynSec.ExecuteAsync(TimeSpan.FromSeconds(10), cmds);

        }
        // GET: api/<MQTTdynsecController>/groups
        [HttpGet("groups")]
        public async Task<ResponseList> GetGroups(bool? verbose)
        {
            var cmds = new CommandsList(new List<AbstractCommand> {
                new ListGroups(verbose ?? true),
            });

            return await dynSec.ExecuteAsync(TimeSpan.FromSeconds(10), cmds);

        }

        // GET: api/<MQTTdynsecController>/groups
        [HttpGet("anonymous-group")]
        public async Task<ResponseList> GetAnonymousGroups()
        {
            var cmds = new CommandsList(new List<AbstractCommand> {
                new GetAnonymousGroup(),
            });

            return await dynSec.ExecuteAsync(TimeSpan.FromSeconds(10), cmds);

        }
    }
}
