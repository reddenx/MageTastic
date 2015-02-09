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
            var recentEntries = new ConsoleEntry[10];
            for (int i = 0; i < Instance.Entries.Count && i < 10; ++i)
            {
                recentEntries[i] = Instance.Entries[Instance.Entries.Count - 1 - i];
            }
            return recentEntries;
        }

        public static void Draw(GameTime gameTime)
        {
            //TODO efficiency
            var recentEntries = Instance.Entries.Take(10);

            foreach (var entry in recentEntries)
            {
                RenderService.DrawConsole(Instance.Entries.ToArray());
            }
        }
    }
}
