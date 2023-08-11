using mqtt_dynsec_manager.DynSec.Commands.Abstract;
using mqtt_dynsec_manager.DynSec.Commands.Helpers;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;
using mqtt_dynsec_manager.DynSec.Responses.Helpers;

namespace mqtt_dynsec_manager.DynSec.Interfaces
{
    public interface IDynSec
    {
        Task<ResponseList> ExecuteAsync(TimeSpan timeout, CommandsList commands);
        Task<ResponseList> ExecuteAsync(CommandsList commands, CancellationToken cancellationToken = default);
        Task<AbstractResponse> ExecuteCommand(AbstractCommand cmd);
    }
}
