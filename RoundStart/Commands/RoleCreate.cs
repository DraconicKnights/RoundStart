using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginAPI.Commands;
using RoundStart.Roles;

namespace RoundStart.Commands
{
    public class RoleCreate : ICommand, IUsageProvider
    {
        public string[] Usage => null;

        public string Command => "Role";

        public string[] Aliases => null;

        public string Description => "Used to manage roles";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            if (arguments.Count < 3)
            {
                response = "Invalid amount of arguemnts provided";
                return true;
            }

            if (!sender.CheckPermission(PlayerPermissions.SetGroup))
            {
                response = "You don't have permission to use this command";
                return true;
            }

            Role role = new Role(1, "moderator", "role");

            Config config = new Config();

            config.Roles.Add(role);


            response = null;
            return true;
        }
    }
}
