using Microsoft.AspNetCore.Mvc;
using mqtt_dynsec_manager.DynSec.Commands;
using mqtt_dynsec_manager.DynSec.Commands.Abstract;
using mqtt_dynsec_manager.DynSec.Commands.Helpers;
using mqtt_dynsec_manager.DynSec.Interfaces;
using mqtt_dynsec_manager.DynSec.Responses;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;
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
        public async Task<ActionResult<RoleListData>> GetRoles(bool? verbose)
        {
            var cmd = new ListRoles(verbose ?? true);
            AbstractResponse result = await dynSec.ExecuteCommand(cmd) ?? new GeneralResponse
            {
                Error = "Task cancelled",
                Command = cmd.Command,
                Data = null
            };

            switch (result.Error)
            {
                case "Ok":
                    var data = ((RoleList)result).Data;
                    return Ok(data);
                case "Task cancelled":
                    return StatusCode(504);
                default:
                    return NotFound(result);
            }
        }

        // GET: api/<MQTTdynsecController>/role/<role>
        [HttpGet("role/{role}")]
        public async Task<ActionResult<RoleInfoData>> GetRole(string role)
        {
            var cmd = new GetRole(role);
            AbstractResponse result = await dynSec.ExecuteCommand(cmd) ?? new GeneralResponse
            {
                Error = "Task cancelled",
                Command = cmd.Command,
                Data = null
            };

            switch (result.Error)
            {
                case "Ok":
                    var data = ((RoleInfo)result).Data;
                    return Ok(data);
                case "Task cancelled":
                    return StatusCode(504);
                default:
                    return NotFound(result);
            }            
        }
    }
}
