using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SinglePlayerEngine.UI.Console;

namespace SinglePlayerEngine.Services
{
    class ConsoleService
    {
        private static ConsoleService Instance;
        private const int RECENT_ENTRY_AMOUNT = 5;

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

        public static ConsoleEntry[] GetRecentConsoleEvents()
        {
            //TODO efficiency
            return Instance.Entries.Reverse<ConsoleEntry>().Take(RECENT_ENTRY_AMOUNT).Reverse().ToArray();
        }

        public static void Draw(GameTime gameTime)
        {
            RenderService.DrawConsole(GetRecentConsoleEvents());
        }
    }
}
