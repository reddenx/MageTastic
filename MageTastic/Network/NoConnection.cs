using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Network
{
    //single player implementation
    class NoConnection : INetworkConnection
    {
        public NoConnection()
        { }

        public void QueueCommand(NetworkCommand command)
        { }

        public NetworkCommand[] GetCommands()
        {
            return new NetworkCommand[] { };
        }

        public void Initialize(object identification)
        { }

        public void Close()
        { }
    }
}
