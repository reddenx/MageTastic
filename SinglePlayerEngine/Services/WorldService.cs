using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SinglePlayerEngine.Services
{
    class WorldService
    {
        private static WorldService Instance;

        public static void Instantiate()
        {
            Instance = new WorldService();
        }

        private WorldService()
        { }

        public static void Update(GameTime gameTime)
        { }
    }
}
