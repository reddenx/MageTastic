using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.GameServices.ServiceModels
{
    class ConsoleEntry
    {
        public readonly DateTime MessageTime;
        public readonly string Message;
        public readonly ConsoleEntryType Type;

        public ConsoleEntry(string message, ConsoleEntryType type)
        {
            MessageTime = DateTime.Now;
            Message = message;
            Type = type;
        }

        private string _complete;
        public string CompleteMessageForConsole
        {
            get
            {
                return _complete ?? (_complete =
                    string.Format("{0}: {1}", Type.ToString(), Message));
            }
        }
    }

    enum ConsoleEntryType
    {
        Info,
        Error,
        CRITICAL,
    }
}
