using System.Linq;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace RoundStart.EventHandler.Events
{
    [Event]
    public class TeslaGateControl
    {
        private static void TeslaControl(TeslaGate tesla)
        {
            foreach (var player in Player.GetPlayers().Where(player => tesla.PlayerInRange(player.ReferenceHub)))
            {
                if (player.Team != Team.FoundationForces) return;

                foreach (var item in player.Items)
                {
                    if (item.ItemTypeId != ItemType.KeycardO5) continue;
                    tesla.enabled = false;
                    tesla.InProgress = false;

                    MEC.Timing.CallDelayed(20, () =>
                    {
                        tesla.enabled = true;
                    });

                }
            }
        }
        
        [PluginEvent(ServerEventType.MapGenerated)]
        public void Main()
        {
            TeslaGate.OnBursted += TeslaControl;
            
            // Get an existing TeslaGate object in the scene
            var tesla = ReferenceHub.HostHub.GetComponent<TeslaGate>();

            TeslaControl(tesla);
        }
    }
}