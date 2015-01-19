using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SinglePlayerEngine.Entities.Physics
{
    abstract class PhysicsComponent
    {
        public Vector2 Position { get; protected set; }

        public abstract bool IsCollidingWith(Entity entity);
        public abstract void Update(GameTime gameTime);
        public abstract bool IsInside(Rectangle rectangle);
        public abstract void ApplyImpulse(Vector2 force);
        public abstract void SetMovementDirection(Vector2 direction);
        public abstract Rectangle GetCollisionRectangle();
    }
}
