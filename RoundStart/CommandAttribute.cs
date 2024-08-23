using System;

namespace RoundStart
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandAttribute : Attribute
    {
        public string CommandName { get; }
        public string Description { get; }
        public string[] Usage { get; }
        public PlayerPermissions RequiredPermission { get; }
        
        public Type[] SupportedHandlers { get; }

        public CommandAttribute(string commandName, string description, string[] usage, PlayerPermissions requiredPermission, Type[] supportedHandlers)
        {
            CommandName = commandName;
            Description = description;
            Usage = usage;
            RequiredPermission = requiredPermission;
            SupportedHandlers = supportedHandlers;
        }
    }
}