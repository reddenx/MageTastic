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
        private readonly List<Entity> NewEntityAdditions;

        public Level()
        {
            Entities = new List<Entity>();
            NewEntityAdditions = new List<Entity>();
        }

        public List<Entity> QueryForCollision(Entity input)
        {
            var colliders = new List<Entity>();
            foreach (var entity in Entities)
            {
                if (entity.IsCollidable && entity.State.CurrentFrame.PhysicsBox.Intersects(input.State.CurrentFrame.PhysicsBox))
                {
                    colliders.Add(entity);
                }
            }

            return colliders;
        }

        public void Update(GameTime gameTime)
        {
            //TODO EFFICIENCY
            //ideally this would play out like this, they would be in
            //linked lists, as we update we'd be transferring objects
            //from one list to another holding and comparing the most
            //recent object's depth to the next, sorting them by Y
            //this would provide us with a SUPER cheap depth display 
            //check, we'd then use this for rendering rather than 
            //traversing again and sorting, but I'm just gonna use linq
            //for now until it becomes a performance issue.

            //TODO EFFICIENCY
            //artifact of using a foreach loop and having entities able 
            //to insert new ones, eventually switch to iterator that supports
            //structure modification during traversal. (would remove need
            //for slow addrange)
            Entities.AddRange(NewEntityAdditions);
            Entities.RemoveAll(uu => uu.RemoveFromWorld);
            NewEntityAdditions.Clear();

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

        internal void AddEntity(Entity entity)
        {
            NewEntityAdditions.Add(entity);
        }
    }
}
