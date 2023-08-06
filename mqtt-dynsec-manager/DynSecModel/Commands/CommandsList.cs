namespace mqtt_dynsec_manager.DynSecModel
{
    public class CommandsList
    {
        public CommandsList() { }
        public CommandsList(List<AbstractCommand> commands)
        { 
            _commands = _commands.Concat(commands).ToList<AbstractCommand>(); 
        }

        private List<AbstractCommand> _commands = new();

        public List<AbstractCommand> commands { get { return _commands; } }


    }
}
