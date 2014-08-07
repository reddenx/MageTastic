using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Engines
{
    class NetworkEngine
    {
        private static NetworkEngine Instance;

        private NetworkEngine()
        { }

        public static void Instantiate()
        {
            if (Instance == null)
            {
                Instance = new NetworkEngine();
            }
        }

        //be able to send messages to targetted objects
        //be able to receive messages and deliver information to targetted
    }
}
