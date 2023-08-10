using mqtt_dynsec_manager.DynSec.Commands.Abstract;
using mqtt_dynsec_manager.DynSec.Model;

namespace mqtt_dynsec_manager.DynSec.Commands.Helpers
{
    public abstract class CMRoleBuilder
    {
        protected string? TextName { get; set; }
        protected string? TextDescription { get; set; }

        protected List<ACLDefinition>? ACLs { get; set; }

        public CMRoleBuilder WithTextName(string _textName) { TextName = _textName; return this; }
        public CMRoleBuilder WithTextDescription(string _textDescription) { TextDescription = _textDescription; return this; }
        public CMRoleBuilder AddACLRule(string topic, string aclType, int priority, bool allow)
        {
            ACLs ??= new();
            ACLs.Add(new ACLDefinition
            {
                Topic = topic,
                ACLType = aclType,
                Priority = priority,
                Allow = allow
            });
            return this;
        }

        public abstract AbstractCommand Build();
    }
}
