using System;
using System.Linq;
using MEC;
using Mirror;
using PluginAPI.Core;
using UnityEngine;

namespace RoundStart.Utils.Dummy
{
    public class DummyManager
    {
        private static int _dummyID = 0;

        public static ReferenceHub CreateDummy(string name)
        {
            var dummy = GameObject.Instantiate(NetworkManager.singleton.playerPrefab);
            _dummyID++;
            int id = _dummyID;
            
            var dcon = new TestPlayerNetwork(id);
            
            var hub = dummy.GetComponent<ReferenceHub>();

            NetworkServer.AddPlayerForConnection(dcon, dummy);

            try
            {
                hub.authManager.NetworkSyncedUserId = $"dummy{id}@server";
                hub.nicknameSync.Network_myNickSync = name;
                hub.authManager.UserId = $"dummy{id}@server";
            }
            catch (Exception)
            {
                // ignored
            }

            return hub;
        }
        
        public static bool DestroyDummy(string ID)
        {
            foreach (var plr in Player.GetPlayers().Where(plr => plr.UserId == ID))
            {
                plr.Kill();

                Timing.CallDelayed(0.2f, () =>
                {
                    NetworkServer.RemovePlayerForConnection(plr.ReferenceHub.connectionToClient, true);
                });

                return true;
            }

            return false;
        }
    }
}