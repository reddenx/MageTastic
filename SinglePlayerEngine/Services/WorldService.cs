using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SinglePlayerEngine.Entities;

namespace SinglePlayerEngine.Services
{
    class WorldService
    {
        private static WorldService Instance;

        private List<Entity> Entities;

        public static void Initialize()
        {
            Instance = new WorldService();
        }

        private WorldService()
        {
            Entities = new List<Entity>();
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var entity in Instance.Entities)
            {
                entity.Update(gameTime);
            }
        }

        //TODO efficiency
        public Entity[] QueryWorldForCollisionsWith(Entity queryEntity)
        {
            return Instance.Entities
                .Where(entity => entity.Physics.IsCollidingWith(queryEntity))
                .ToArray();
        }

        public static Entity[] GetDrawableEntitiesWithin(Rectangle rectangle)
        {
            return Instance.Entities
                .Where(entity => entity.Physics.IsInside(rectangle))
                .ToArray();
        }
    }
}
