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
        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle(
                    (int)(Position.X - Origin.X + CollisionBoxDimensions.X),
                    (int)(Position.Y - Origin.Y + CollisionBoxDimensions.Y),
                    CollisionBoxDimensions.Width,
                    CollisionBoxDimensions.Height);
            }
        }

        protected readonly Rectangle CollisionBoxDimensions;
        protected readonly Point BoundingBoxDimensions;
        protected readonly Vector2 Origin;
        protected readonly Texture2D Texture;

        public Vector2 Position;
        public bool IsCollidable = true;

        public Entity(Rectangle collisionBoxDimensions, Point boundingBoxDimensions, Vector2 origin, Texture2D texture, Vector2 position)
        {
            CollisionBoxDimensions = collisionBoxDimensions;
            BoundingBoxDimensions = boundingBoxDimensions;
            Origin = origin;
            Texture = texture;
            Position = position;
        }

        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);
        abstract public void HandleCollision(Entity colliders);
    }
}
