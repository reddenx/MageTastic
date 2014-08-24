using MageTastic.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Engines
{
    class NetworkEngine
    {
        private static NetworkEngine Instance;
        private INetworkConnection Connection;

        private NetworkEngine()
        {
        }

        public static void Instantiate()
        {
            if (Instance == null)
            {
                Instance = new NetworkEngine();
            }
        }

        public static void StartHosting()
        {
            Instance.Connection = new ServerConnection(37017);
        }

        public static void NotifyEntity(EntityPayload message)
        {
            NetworkCommand command = new NetworkCommand(NetworkCommandDestination.Entity, message);
            Instance.Connection.QueueCommand(command);
        }
    }
}
