using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace RoundStart.EventHandler
{
    public class EventStartHandler
    {
        [PluginEvent(ServerEventType.RoundStart)]
        void OnRoundStart()
        {
            
        }
    }
}