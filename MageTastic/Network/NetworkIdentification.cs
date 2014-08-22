using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Network
{
    [Serializable]
    class NetworkIdentification
    {
        public readonly string Username;

        public NetworkIdentification(string username)
        {
            Username = username;
        }
    }
}
