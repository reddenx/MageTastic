using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MageTastic.Network
{
    class ClientConnection : INetworkConnection
    {
        private readonly TcpClient Client;
        private Thread SendThread;
        private Thread ReceiveThread;
        private int UserId;

        public ClientConnection(string host, int port)
        {
        }

        public void QueueCommand(NetworkCommand command)
        {
            throw new NotImplementedException();
        }

        public NetworkCommand[] GetCommands()
        {
            throw new NotImplementedException();
        }

        public void Initialize(object identification)
        {
            throw new NotImplementedException();
        }

        private void Connect()
        {
            //connect
            //get userid immediately
            //spin off receive thread
            //spin off send thread
        }
    }
}
