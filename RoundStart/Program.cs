using System;
using System.Linq;
using System.Reflection;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;

namespace RoundStart
{
    public class Plugin
    {
        [PluginConfig]
        public static Config Config;

        [PluginEntryPoint("Round Start", "1.0", "Round Start Plugin", "Draconic")]
        public void OnPluginStart()
        {
            Log.Info("$Plugin is loading");
            
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var eventClasses = assembly.GetTypes().Where(type => type.GetCustomAttribute<EventAttribute>() != null);

            foreach (var eventClass in eventClasses)
            {
                var newEvent = Activator.CreateInstance(eventClass);
                EventManager.RegisterEvents(newEvent);
            }
        }
    }
    
}
