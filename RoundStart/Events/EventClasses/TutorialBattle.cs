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
        int TutorialTime = 10;
        public void TutorialEvent()
        {
                Tutorial(Events.TutorialBattleStart);

                
        }

        public void Tutorial(Events events)
        {
            switch (events) {
                case Events.TutorialBattleStart:
                   foreach (Player player in PlayerList.GetPlayers())
                    {

                    }
                    break;
            }
        }


        public enum Events
        {
            TutorialBattleStart, TutorialBattleEnd, TutorialBattleStatus,
        }
        
       
    }
}
