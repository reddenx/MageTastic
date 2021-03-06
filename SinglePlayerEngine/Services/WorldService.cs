﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SinglePlayerEngine.Entities;
using SinglePlayerEngine.World;

namespace SinglePlayerEngine.Services
{
    class WorldService
    {
        private static WorldService Instance;

        private WorldDirector Director;
        private List<Entity> NewEntities;
        private List<Entity> Entities;

        public static void Initialize()
        {
            Instance = new WorldService();
            ConsoleService.RecordInfo("World Service Initialized");
        }

        private WorldService()
        {
            Entities = new List<Entity>();
            NewEntities = new List<Entity>();
            Director = new WorldDirector();
        }

        public static void StartupWorld()
        {
            Instance.Entities.Clear();
            Instance.NewEntities.Clear();
            Instance.Director.Reset();
            Instance.Director.PlacePlayerInWorld();
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var entity in Instance.Entities)
            {
                entity.Update(gameTime);
            }

            Instance.Entities.AddRange(Instance.NewEntities);
            Instance.NewEntities.Clear();
        }

        //TODO efficiency
        public Entity[] QueryWorldForCollisionsWith(Entity queryEntity)
        {
            return Instance.Entities
                .Where(entity => entity.Physics.IsCollidingWith(queryEntity))
                .ToArray();
        }

        //TODO efficiency
        public static Entity[] GetDrawableEntitiesWithin(Rectangle rectangle)
        {
            return Instance.Entities
                .Where(entity => entity.Physics.IsInside(rectangle))
                .ToArray();
        }

        public static void AddEntity(Entity player)
        {
            Instance.NewEntities.Add(player);
        }
    }
}
