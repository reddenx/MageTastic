using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace MageTastic.Network
{
    class ServerConnection : INetworkConnection
    {
        private List<NetworkCommand> InCommands;
        private List<NetworkCommand> OutCommands;
        private List<ServerClientConnection> ConnectedClients;
        private TcpListener Listener;
        private readonly int Port;
        private int UserIdCounter;
        private Thread ConnectionThread;

        private string Username;

        public ServerConnection(int port)
        {
            ConnectedClients = new List<ServerClientConnection>();
            InCommands = new List<NetworkCommand>();
            OutCommands = new List<NetworkCommand>();
            Port = port;
            UserIdCounter = 0;
            StartupServer();
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
                if (InCommands.Count != 0)
                {
                    var commandList = InCommands.ToArray();
                    InCommands.Clear();
                    return commandList;
                }
            }
            return new NetworkCommand[0];
        }

        public void Initialize(object identification)
        {
            Username = identification as string;
        }

        private void StartupServer()
        {
            ConnectionThread = new Thread(new ThreadStart(ConnectionLoop));
            ConnectionThread.IsBackground = true;
            ConnectionThread.Start();
        }

        private void ConnectionLoop()
        {
            Listener = new TcpListener(new IPEndPoint(IPAddress.Any, Port));
            Listener.Start();
            while (true)
            {
                var newClient = Listener.AcceptTcpClient();
                var newClientConnection = HandShake(newClient);
                ConnectedClients.Add(newClientConnection);
            }
        }

        private ServerClientConnection HandShake(TcpClient newClient)
        {
            var thread = new Thread(new ParameterizedThreadStart(ReceiveLoop));
            thread.IsBackground = true;
            var userId = UserIdCounter++;
            var clientConnection = new ServerClientConnection(thread, newClient, userId);

            //TODO handshake logic here
            (new BinaryFormatter()).Serialize(newClient.GetStream(), userId);//sending userid right now, needs more info
            //
            //
            //
            //

            thread.Start(clientConnection);
            return clientConnection;
        }

        private void ReceiveLoop(object context)
        {
            var connectionContext = context as ServerClientConnection;
            var formatter = new BinaryFormatter();
            var netStream = connectionContext.ClientConnection.GetStream();

            try
            {
                while (true)
                {
                    var command = formatter.Deserialize(netStream) as NetworkCommand;
                    lock (InCommands)
                    {
                        InCommands.Add(command);
                    }

                    EchoAll(command, connectionContext.UserId);
                }
            }
            catch (IOException e)
            {
                //client closed
                connectionContext.ClientConnection.Close();
                ConnectedClients.Remove(connectionContext);
            }
        }

        private void EchoAll(NetworkCommand command, int userId)
        {
            //can't foreach a list that's liable to change when clients connect
            for (int i = 0; i < ConnectedClients.Count; ++i)
            {
                if (ConnectedClients[i].UserId != userId)
                {
                    SendMessage(ConnectedClients[i].ClientConnection.GetStream(), command);
                }
            }
        }

        private void SendMessage(NetworkStream client, object message)
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(client, message);
        }

        private class ServerClientConnection
        {
            public readonly Thread ReceiveThread;
            public readonly TcpClient ClientConnection;
            public readonly int UserId;
            //TODO more data from identification object

            public ServerClientConnection(Thread recvThread, TcpClient connection, int userId)
            {
                ReceiveThread = recvThread;
                ClientConnection = connection;
                UserId = userId;
            }
        }


        public void Close()
        {
            try { Listener.Stop(); }
            catch { }

            try { ConnectionThread.Abort(); }
            catch { }

            foreach (var connection in ConnectedClients)
            {
                try { connection.ReceiveThread.Abort(); }
                catch { }

                try { connection.ClientConnection.Close(); }
                catch { }
            }
        }
    }
}
