using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SinglePlayerEngine.Entities.Physics
{
    /*
     * current physics triad from: Mu(Vm + F) = F
     * Mu = F / (Vm + F)
     * V = (F - FMu) / Mu
     * F = -MuVm / (Mu - 1)
     */

    class MovingPhysicalEntity : PhysicsComponent
    {
        private Vector2 CollisionBoxSize;
        private Vector2 Origin;

        private Vector2 Position;
        private Vector2 Velocity;
        private Vector2 Acceleration;

        private float Mu;
        private float MaxVelocity;
        private float Force;

        public override void Update(GameTime gameTime)
        {
            var seconds = gameTime.ElapsedGameTime.TotalSeconds;
            Acceleration = Vector2.Zero;
        }

        public override bool IsCollidingWith(Entity entity)
        {
            return false;
        }

        public override bool IsInside(Rectangle rectangle)
        {
            return true;
        }

        public override void ApplyForce(Vector2 force)
        {
            //TODO THIS IS WHERE YOU LEFT OFF 20150117
        }
    }
}
