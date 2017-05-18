using Microsoft.Xna.Framework;
using Spellers.GameServices.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.GameServices
{
    class ConsoleService
    {
        private static ConsoleService Instance;

        private List<ConsoleEntry> Entries;

        public static void Initialize()
        {
            Instance = new ConsoleService();
        }

        private ConsoleService()
        {
            Entries = new List<ConsoleEntry>();
            Entries.Add(new ConsoleEntry("Console Startup", ConsoleEntryType.Info));
        }

        public static void Update(GameTime gameTime)
        {
        }

        public static void RecordInfo(string info)
        {
            Instance.Entries.Add(new ConsoleEntry(info, ConsoleEntryType.Info));
        }

        public static void RecordError(string error)
        {
            Instance.Entries.Add(new ConsoleEntry(error, ConsoleEntryType.Error));
        }

        public static void RecordCriticalEvent(string criticalEvent)
        {
            Instance.Entries.Add(new ConsoleEntry(criticalEvent, ConsoleEntryType.CRITICAL));
        }

        public static ConsoleEntry[] GetRecentConsoleEvents(int amount)
        {
            return Instance.Entries.Skip(Math.Max(0, Instance.Entries.Count() - amount)).ToArray();
        }
    }
}
