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
        public Vector2 Position;
        public bool IsCollidable = true;
        protected EntityAnimationState Animations;

        public abstract EntityFrame CurrentStateFrame { get; }

        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);
        abstract public void HandleCollision(Entity colliders);
    }
}
