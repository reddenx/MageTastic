using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.Physics
{
    class Body<T>
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Force;

        public float Rotation;
        public float AngularVelocity;
        public float Torque;

        public float Mass;
        //probably not going to need these until a full rigid body simulator is necessary
        //public float InverseMass;
        //public float Inertia;
        //public float InverseInertia;

        public float StaticFriction;
        public float DynamicFriction;
        public float Bounciness;

        public bool IsAtRest
        {
            get { return Velocity.LengthSquared() < 10 && Math.Abs(AngularVelocity) < .05f; }
        }

        public T Shape;

        public Body(
            T shape,
            float mass,
            Vector2 position,
            int width,
            int height,
            float rotation,
            Vector2? velocity = null,
            float angularVelocity = 0,
            float staticFriction = .8f,
            float dynamicFriction = .3f,
            float bounciness = .2f)
        {
            this.Shape = shape;
            this.Velocity = velocity ?? Vector2.Zero;
            this.Force = Vector2.Zero;

            this.AngularVelocity = angularVelocity;
            this.Torque = 0;

            this.Mass = mass;
            this.InverseMass = 1f / mass;
            this.Inertia = GetInertia(mass, width, height);
            this.InverseInertia = 1f / Inertia;

            this.StaticFriction = staticFriction;
            this.DynamicFriction = dynamicFriction;
            this.Bounciness = bounciness;
        }

        public void ApplyImpulse(Vector2 impulse, Vector2 contactVector)
        {
            Velocity += InverseMass * impulse;
            AngularVelocity += InverseInertia * contactVector.Cross(impulse);
        }

        public void ApplyForce(Vector2 force)
        {
            Force += force;
        }

        private static float GetInertia(float mass, float width, float height)
        {
            return (mass / 12) * ((height * height) + (width * width));
        }

        public Rectangle GetBounds()
        {
            var collisionRadius = Shape.CollisionRadius;
            var fudge = 5;
            return new Rectangle(
                (int)(Position.X - collisionRadius - fudge),
                (int)(Position.Y - collisionRadius - fudge),
                (int)(Shape.CollisionRadius * 2 + (fudge * 2)),
                (int)(Shape.CollisionRadius * 2 + (fudge * 2)));
        }
    }
}
