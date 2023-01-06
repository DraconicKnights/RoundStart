using InventorySystem.Items;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Playables;

namespace RoundStart.Events
{
    public class TutorialBattle
    {
        public void TutorialEvent()
        {
            foreach (Player player in PlayerList.GetPlayers()) 
            {
                player.SetRole(RoleTypeId.Tutorial, RoleChangeReason.RoundStart);
                
            }
        }
    }
}
