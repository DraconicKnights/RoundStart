using System;
using CommandSystem;
using PluginAPI.Core;

namespace RoundStart.Commands
{
    public abstract class CommandCore : ICommand, IUsageProvider
    {
        public string Command { get; }
        public string[] Aliases => null;
        public string Description { get; }
        public string[] Usage { get; }

        protected CommandCore()
        {
            var attributes = (CommandAttribute)Attribute.GetCustomAttribute(GetType(), typeof(CommandAttribute));
            Command = attributes.CommandName;
            Description = attributes.Description;
            Usage = attributes.Usage;
        }

        protected abstract bool Execute(Player player, ArraySegment<string> arguments, out string response);
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!CheckPermissions(sender))
            {
                response = "You do not have the necessary permissions.";
                return false;
            }
            
            var player = (Player)sender;
        
            return Execute(player, arguments, out response);
        }

        private bool CheckPermissions(ICommandSender sender)
        {
            // Retrieve attribute from this instance
            var attributes = (CommandAttribute[])GetType().GetCustomAttributes(typeof(CommandAttribute), true);
        
            if (attributes.Length > 0)
            {
                var requiredPermission = attributes[0].RequiredPermission;
            
                // Assuming player.HasValueForPermission is a method that checks for permissions
                return sender.CheckPermission(requiredPermission);
            }

            // If no permission attribute is set, we let the command execute by default.
            return true;
        
        }

    }
}