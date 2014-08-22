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
        private readonly INetworkConnection Connection;

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

        public static void NotifyEntity(uint entityId, object message)
        {
            throw new NotImplementedException();

            //possible command types for entities
            //state change
            //position change
            //attribute change

            //build command
            NetworkCommand command = null;

            Instance.Connection.QueueCommand(command);
        }
    }
}
