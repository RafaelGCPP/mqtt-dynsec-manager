﻿using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public class SetClientId : AbstractCommand
    {
        public SetClientId(string _username, string _clientId) : base("setClientId")
        {
            UserName = _username;
            ClientId = _clientId;
        }
        public string? UserName { get; set; }
        public string? ClientId { get; set; }
    }
}
