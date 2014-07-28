using MageTastic.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.World
{
    class Level
    {
        private readonly List<Entity> Entities;

        public Level()
        {
            Entities = new List<Entity>();
        }

        public List<Entity> QueryForCollision(Entity input)
        {
            var colliders = new List<Entity>();
            foreach (var entity in Entities)
            {
                if (entity.IsCollidable && entity.CurrentStateFrame.PhysicsBox.Intersects(input.CurrentStateFrame.PhysicsBox))
                {
                    colliders.Add(entity);
                }
            }

            return colliders;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var entity in Entities)
            {
                entity.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var entity in Entities)
            {
                entity.Draw(spriteBatch);
            }
        }
    }
}
