using Microsoft.AspNetCore.Mvc;
using mqtt_dynsec_manager.DynSec.Commands;
using mqtt_dynsec_manager.DynSec.Commands.Abstract;
using mqtt_dynsec_manager.DynSec.Commands.Helpers;
using mqtt_dynsec_manager.DynSec.Interfaces;
using mqtt_dynsec_manager.DynSec.Responses.Helpers;

namespace mqtt_dynsec_manager.Controllers.DynamicSecurity
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IDynSec dynSec;

        public GroupsController(IDynSec _dynSec) { dynSec = _dynSec; }

        // GET: api/<MQTTdynsecController>/groups
        [HttpGet("groups")]
        public async Task<ResponseList> GetGroups(bool? verbose)
        {
            var cmds = new CommandsList(new List<AbstractCommand> {
                new ListGroups(verbose ?? true),
            });

            return await dynSec.ExecuteAsync(TimeSpan.FromSeconds(10), cmds);

        }

        // GET: api/<MQTTdynsecController>/group/<group>
        [HttpGet("group/{group}")]
        public async Task<ResponseList> GetGroup(string group)
        {
            var cmds = new CommandsList(new List<AbstractCommand>
            {
                new GetGroup(group),
            });

            return await dynSec.ExecuteAsync(TimeSpan.FromSeconds(10), cmds);
        }

        // GET: api/<MQTTdynsecController>/anonymous-group
        [HttpGet("anonymous-group")]
        public async Task<ResponseList> GetAnonymousGroups()
        {
            var cmds = new CommandsList(new List<AbstractCommand> {
                new GetAnonymousGroup(),
            });

            return await dynSec.ExecuteAsync(TimeSpan.FromSeconds(10), cmds);
        }

        // POST: api/<MQTTdynsecController>/anonymous-group
        [HttpPost("anonymous-group")]
        public async Task<ResponseList> SetAnonymousGroups([FromBody] string group)
        {
            var cmds = new CommandsList(new List<AbstractCommand>
            {
                new SetAnonymousGroup(group),
            });


            return await dynSec.ExecuteAsync(TimeSpan.FromSeconds(10), cmds);
        }
    }
}
