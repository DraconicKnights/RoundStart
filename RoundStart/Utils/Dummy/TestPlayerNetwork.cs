using System;
using Mirror;

namespace RoundStart.Utils.Dummy
{
    public class TestPlayerNetwork : NetworkConnectionToClient
    {
        public TestPlayerNetwork(int networkConnectionId) : base(networkConnectionId)
        {
        }

        public override string address => "AtTheInn";
        public override void Send(ArraySegment<byte> segment, int channelId = 0)
        {

        }
        public override void Disconnect()
        {
            NetworkServer.RemovePlayerForConnection(identity.gameObject.GetComponent<ReferenceHub>().connectionToServer, true);
        }
    }
}