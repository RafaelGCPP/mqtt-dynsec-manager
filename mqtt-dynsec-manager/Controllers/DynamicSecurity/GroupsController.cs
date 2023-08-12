using Microsoft.AspNetCore.Mvc;
using mqtt_dynsec_manager.DynSec.Commands;
using mqtt_dynsec_manager.DynSec.Commands.Abstract;
using mqtt_dynsec_manager.DynSec.Interfaces;
using mqtt_dynsec_manager.DynSec.Responses;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;
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
        public async Task<ActionResult<GroupListData>> GetGroups(bool? verbose)
        {
            var cmd = new ListGroups(verbose ?? true);
            AbstractResponse result = await dynSec.ExecuteCommand(cmd) ?? new GeneralResponse
            {
                Error = "Task cancelled",
                Command = cmd.Command,
                Data = null
            };

            switch (result.Error)
            {
                case "Ok":
                    var data = ((GroupList)result).Data;
                    return Ok(data);
                case "Task cancelled":
                    return StatusCode(504);
                default:
                    return NotFound(result);
            }
        }

        // GET: api/<MQTTdynsecController>/group/<group>
        [HttpGet("group/{group}")]
        public async Task<ActionResult<GroupInfoData>> GetGroup(string group)
        {
            var cmd = new GetGroup(group);
            var result = await dynSec.ExecuteCommand(cmd) ?? new GeneralResponse
            {
                Error = "Task cancelled",
                Command = cmd.Command,
                Data = null
            };

            switch (result.Error)
            {
                case "Ok":
                    var data = ((GroupInfo)result).Data;
                    return Ok(data);
                case "Task cancelled":
                    return StatusCode(504);
                default:
                    return NotFound(result);
            }

        }

        // GET: api/<MQTTdynsecController>/anonymous-group
        [HttpGet("anonymous-group")]
        public async Task<ActionResult<AnonymousGroupInfoData>> GetAnonymousGroups()
        {
            var cmd = new GetAnonymousGroup();
            var result = await dynSec.ExecuteCommand(cmd) ?? new GeneralResponse
            {
                Error = "Task cancelled",
                Command = cmd.Command,
                Data = null
            };

            switch (result.Error)
            {
                case "Ok":
                    var data = ((AnonymousGroupInfo)result).Data;
                    return Ok(data);
                case "Task cancelled":
                    return StatusCode(504);
                default:
                    return NotFound(result);
            }
        }

        // POST: api/<MQTTdynsecController>/anonymous-group
        [HttpPost("anonymous-group")]
        public async Task<ActionResult<GeneralResponse>> SetAnonymousGroups([FromBody] string group)
        {
            var cmd = new SetAnonymousGroup(group);

            var result = await dynSec.ExecuteCommand(cmd) ?? new GeneralResponse
            {
                Error = "Task cancelled",
                Command = cmd.Command,
                Data = null
            };
            switch (result.Error)
            {
                case "Ok":
                    return Ok();
                case "Task cancelled":
                    return StatusCode(504);
                default:
                    return NotFound(result);
            }
        }
    }
}
