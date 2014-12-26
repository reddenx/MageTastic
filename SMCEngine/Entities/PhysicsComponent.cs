using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SMCEngine.Entities
{
    public class PhysicsComponent
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Acceleration;
        public float Rotation;
        public float RotationVelocity;
        public Vector2 Origin;

        public void Update(GameTime gameTime)
        {
            var elapsedTimeScale = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Velocity += Acceleration;
            Position += Velocity * elapsedTimeScale;
            Rotation += RotationVelocity * elapsedTimeScale;
        }
    }
}
