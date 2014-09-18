using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace MageTastic.Network
{
    class ClientConnection : INetworkConnection
    {
        private readonly TcpClient Client;
        private readonly string HostName;
        private readonly int Port;
        private readonly Thread SendThread;
        private readonly Thread ReceiveThread;

        private readonly List<NetworkCommand> InCommands;
        private readonly List<NetworkCommand> OutCommands;

        private int UserId;
        private string Username;

        public ClientConnection(string host, int port)
        {
            HostName = host;
            Port = port;
            Client = new TcpClient();

            SendThread = new Thread(new ThreadStart(SendLoop));
            SendThread.IsBackground = true;

            ReceiveThread = new Thread(new ThreadStart(ReceiveLoop));
            ReceiveThread.IsBackground = true;

            InCommands = new List<NetworkCommand>();
            OutCommands = new List<NetworkCommand>();

            Connect();
        }

        public void QueueCommand(NetworkCommand command)
        {
            lock (OutCommands)
            {
                OutCommands.Add(command);
            }
        }

        public NetworkCommand[] GetCommands()
        {
            lock (InCommands)
            {
                var commands = InCommands.ToArray();
                InCommands.Clear();
                return commands;
            }
        }

        public void Initialize(object identification)
        {
            //TODO solidify identification information
            Username = identification as string;
        }

        private void Connect()
        {
            Client.Connect(HostName, Port);

            HandShake();

            ReceiveThread.Start();
            SendThread.Start();
        }

        private void HandShake()
        {
            var stream = Client.GetStream();
            var formatter = new BinaryFormatter();

            var handshakeMessage = formatter.Deserialize(stream);

            UserId = (int)handshakeMessage;
        }

        private void SendLoop()
        {
            var formatter = new BinaryFormatter();
            var stream = Client.GetStream();
            var isEmpty = false;

            while (true)
            {
                NetworkCommand[] commands = null;
                lock (OutCommands)
                {
                    if (OutCommands.Count > 0)
                    {
                        commands = OutCommands.ToArray();
                        OutCommands.Clear();
                    }
                    else
                    {
                        isEmpty = true;
                    }
                }

                if (isEmpty)
                {
                    Thread.Sleep(10);
                }
                else if (commands != null)
                {
                    foreach (var command in commands)
                    {
                        formatter.Serialize(stream, command);
                    }
                }
            }
        }

        private void ReceiveLoop()
        {
            var formatter = new BinaryFormatter();
            var stream = Client.GetStream();

            while (true)
            {
                var command = formatter.Deserialize(stream) as NetworkCommand;

                lock (InCommands)
                {
                    InCommands.Add(command);
                }
            }
        }

        public void Close()
        {
            try { SendThread.Abort(); }
            catch { }

            try { ReceiveThread.Abort(); }
            catch { }

            try { Client.Close(); }
            catch { }
        }
    }
}
