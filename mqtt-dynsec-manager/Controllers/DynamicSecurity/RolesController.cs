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
    public class RolesController : ControllerBase
    {
        private readonly IDynSec dynSec;

        public RolesController(IDynSec _dynSec) { dynSec = _dynSec; }

        // GET: api/<MQTTdynsecController>/roles
        [HttpGet("roles")]
        public async Task<ResponseList> GetRoles(bool? verbose)
        {
            var cmds = new CommandsList(new List<AbstractCommand>
            {
                new ListRoles(verbose ?? true),
            });

            return await dynSec.ExecuteAsync(TimeSpan.FromSeconds(10), cmds);
        }

        // GET: api/<MQTTdynsecController>/role/<role>
        [HttpGet("role/{role}")]
        public async Task<ResponseList> GetRole(string role)
        {
            var cmds = new CommandsList(new List<AbstractCommand>
            {
                new GetRole(role),
            });

            return await dynSec.ExecuteAsync(TimeSpan.FromSeconds(10), cmds);
        }
    }
}
