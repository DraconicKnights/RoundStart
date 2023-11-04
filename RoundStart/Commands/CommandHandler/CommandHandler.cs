using CommandSystem;

namespace RoundStart.Commands.CommandHandler
{
    public abstract class CustomCommandHandler
    {
        public interface ICustomCommandHandler : ICommand, IUsageProvider
        {
            string CustomPermission { get; }
            bool ServerCommand { get; }
            
        }
        
    }
}