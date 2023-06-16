using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerRoles;
using PluginAPI.Core.Attributes;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace RoundStart.Events
{
    public class SpawnEvent
    {
        public void TeslaEvent()
        {
            var tesla = typeof(TeslaGate).GetMethod("_DoShock", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        }

    }
}
