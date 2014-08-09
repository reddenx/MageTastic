﻿using MageTastic.Entities;
using MageTastic.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Engines
{
    //provides global access to the instance of the world and it's methods
    class WorldEngine
    {
        private static WorldEngine Instance;

        private Level CurrentLevel;

        private WorldEngine()
        {
        }

        public static void Initialize()
        {
            if (Instance == null)
            {
                Instance = new WorldEngine();
            }
        }

        public static void SetLevel(Level level)
        {
            Instance.CurrentLevel = level;
        }

        public static void AddEntityToWorld(Entity entity)
        {
            Instance.CurrentLevel.AddEntity(entity);
        }
    }
}