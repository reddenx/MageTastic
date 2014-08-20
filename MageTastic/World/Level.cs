using MageTastic.Engines;
using MageTastic.Entities;
using MageTastic.Entities.Characters;
using MageTastic.Utility;
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
        private readonly Tile[,] TileMap;
        private readonly Director Director;

        public Level()
        {
            Director = new Director();
            Entities = new List<Entity>();
            NewEntityAdditions = new List<Entity>();
            TileMap = Assets.LevelOneTileMap;
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

            DetermineCollisions();

            Director.Update(gameTime);
        }

        private void DetermineCollisions()
        {
            //TODO efficiency
            //stupidly inefficient n^2(ish) algorithm
            foreach (var entity in Entities)
            {
                if (entity.IsCollidable)
                {
                    foreach (var check in Entities)
                    {
                        if (check.IsCollidable && entity.IsCollidable && check != entity && entity.GetTranslatedPhysicsRectangle().Intersects(check.GetTranslatedPhysicsRectangle()))
                        {
                            check.State.HandleCollision(entity);
                            entity.State.HandleCollision(check);
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            RenderEngine.DrawTileMapInView(TileMap, spriteBatch);

            foreach (var entity in Entities.OrderBy(uu => uu.Position.Y))
            {
                entity.Draw(spriteBatch);
            }

            spriteBatch.DrawString(
                Assets.DevFont,
                Entities.Count.ToString(),
                Vector2.Zero,
                Color.Black,
                0f,
                new Vector2(0, -20),
                .2f,
                SpriteEffects.None,
                0f);
        }

        internal void AddEntity(Entity entity)
        {
            NewEntityAdditions.Add(entity);
        }

        //TODO EFFICIENCY laughing at this, had to make it quick and dirty, change it when it becomes a problem
        public IEnumerable<Entity> GetEntitiesOfTeam(EntityTeam entityTeam)
        {
            return Entities.Where(uu => (uu is Character && ((Character)uu).Team == entityTeam));
        }
    }
}
