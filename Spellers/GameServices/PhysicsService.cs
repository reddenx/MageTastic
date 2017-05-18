using Microsoft.Xna.Framework;
using Spellers.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.GameServices
{
    class PhysicsService
    {
        public static PhysicsService Instance;

        public static void Initialize()
        {
            Instance = new PhysicsService();
        }

        public static void Update(GameTime gameTime) { }
        public static void AddToSimulation(GameObject obj) { }
    }
}
