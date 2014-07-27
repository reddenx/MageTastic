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
        public bool Collidable;
        public Rectangle CollisionBox;
        public Rectangle BoundingBox;
        public Vector2 Position;

        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);
    }
}
