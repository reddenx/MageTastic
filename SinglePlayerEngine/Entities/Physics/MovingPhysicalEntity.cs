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

        private Vector2 Velocity;
        private Vector2 Impulse;
        private Vector2 MovementDirection;

        private float Mu;
        private float MaxVelocity;
        private float MoveForce;

        public MovingPhysicalEntity(Vector2 position, Vector2 origin, Vector2 collisionBoxSize, float maxVelocity, float acceleration)
        {
            Position = position;
            Origin = origin;
            CollisionBoxSize = collisionBoxSize;

            CalculateMovementNoMu(maxVelocity, acceleration);
        }

        public override void Update(GameTime gameTime)
        {
            var seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            var scaledAcceleration = MovementDirection * MoveForce;

            Velocity = -Mu * (Velocity + scaledAcceleration) + (Velocity + scaledAcceleration);

            Position += Velocity * (float)seconds;
        }

        public override bool IsInside(Rectangle rectangle)
        {
            return GetCollisionRectangle().Intersects(rectangle);
        }

        public override void ApplyImpulse(Vector2 force)
        {
            Impulse += force;
        }

        public override void SetMovementDirection(Vector2 direction)
        {
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }
            MovementDirection = direction;
        }

        public override bool IsCollidingWith(Entity entity)
        {
            return entity.Physics.GetCollisionRectangle().Intersects(GetCollisionRectangle());
        }

        public override Rectangle GetCollisionRectangle()
        {
            return new Rectangle(
                (int)(Position.X - Origin.X),
                (int)(Position.Y - Origin.Y),
                (int)CollisionBoxSize.X,
                (int)CollisionBoxSize.Y);
        }

        private void CalculateMovementNoMu(float maxVelocity, float force)
        {
            Mu = force / (maxVelocity + force);
            MoveForce = force;
            MaxVelocity = maxVelocity;
        }

        private void CalculateMovementNoF(float maxVelocity, float mu)
        {
            MoveForce = (-mu * maxVelocity) / (mu - 1);
            Mu = mu;
            MaxVelocity = maxVelocity;
        }

        private void CalculateMovementNoVm(float force, float friction)
        {
            MoveForce = force;
            Mu = friction;
            MaxVelocity = (force - force * friction) / friction;
        }
    }
}
