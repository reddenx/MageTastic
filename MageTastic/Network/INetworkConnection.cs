using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Network
{
    interface INetworkConnection
    {
        void QueueCommand(NetworkCommand command);
        NetworkCommand[] GetCommands();
        void Initialize(object identification);
        void Close();
    }
}
