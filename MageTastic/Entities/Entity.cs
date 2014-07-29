using MageTastic.Entities.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Entities
{
    abstract class Entity
    {
        //TODO make them readonly with proper constructor once responsibilities are solidified
        public Vector2 Position;
        public bool IsCollidable = true;
        public Texture2D Texture;
        protected EntityState State;

        public abstract EntityFrame CurrentStateFrame { get; }

        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);
        abstract public void HandleCollision(Entity colliders);
    }
}
