using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.Projectiles
{
    abstract class ProjectileBase : Entity
    {
        public ProjectileBase(Dictionary<EntityState, EntityFrame[][]> animationSet, Texture2D texture, bool isCollidable, Vector2 position)
            : base(animationSet, texture, isCollidable, position)
        {
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void HandleCollision(Entity collider)
        {
            throw new NotImplementedException();
        }
    }
}
