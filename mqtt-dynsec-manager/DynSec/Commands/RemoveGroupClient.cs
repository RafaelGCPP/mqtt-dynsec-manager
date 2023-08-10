﻿using mqtt_dynsec_manager.DynSec.Commands.Abstract;

namespace mqtt_dynsec_manager.DynSec.Commands
{
    public class RemoveGroupClient : AbstractCommand
    {
		public RemoveGroupClient(string groupname, string username) : base("removeGroupClient") 
		{ 
			GroupName = groupname;
            UserName = username;
		}
        public string GroupName { get; set; }
        public string UserName { get; set; }
    }
}
/*
{
	"commands":[
		{
			"command": "removeGroupClient",
			"groupname": "group to remove client from",
			"username": "client to remove from group"
		}
	]
} 
 
 */