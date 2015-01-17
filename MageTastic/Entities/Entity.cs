using MageTastic.Engines;
using MageTastic.Entities.States;
using MageTastic.Entities.States.CharacterStates;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Entities
{
    enum EntityTeam
    {
        Players,
        Enemies,
        Neutral
    }

    abstract class Entity
    {
        //data
        public Vector2 Position;
        public Vector2 Acceleration;
        public Vector2 Velocity;
        private float Friction = .6f;

        public bool IsCollidable;
        public readonly Texture2D Texture;
        public readonly Dictionary<EntityState, EntityFrame[][]> AnimationSet;
        public bool RemoveFromWorld;
        public readonly uint ID;

        //logic
        public AnimatedStateBase State;

        public Entity(Dictionary<EntityState, EntityFrame[][]> animationSet,
            Texture2D texture,
            bool isCollidable,
            Vector2 position)
        {
            AnimationSet = animationSet;
            Texture = texture;
            IsCollidable = isCollidable;
            Position = position;
            ID = WorldEngine.GetNextEntityId();
        }



        //methods
        public virtual void Update(GameTime gameTime)
        {
            Velocity += Acceleration;
            Position += Velocity;
            Velocity *= Friction;
            Acceleration = Vector2.Zero;
        }
        abstract public void Draw(SpriteBatch spriteBatch);
        abstract public void HandleCollision(Entity collider);


        public Rectangle GetTranslatedPhysicsRectangle()
        {
            var frame = State.CurrentFrame;
            var phys = frame.PhysicsBox;
            var pos = Position - frame.Origin;
            var translated = new Rectangle((int)(phys.X + pos.X), (int)(phys.Y + pos.Y), phys.Width, phys.Height);

            return translated;
        }

    }
}
