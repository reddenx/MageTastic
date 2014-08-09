using MageTastic.Engines;
using MageTastic.Entities.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities
{
    class ProjectileProtoBlueOrb : Entity
    {
        private Vector2 Velocity;

        public ProjectileProtoBlueOrb(Dictionary<EntityStates, EntityFrame[][]> animationSet, Texture2D texture, Vector2 position, Vector2 velocity)
            :base(animationSet, texture, true, position)
        {
            Velocity = velocity;
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            RenderEngine.DrawProjectileProto(this);
        }

        public override void HandleCollision(Entity colliders)
        {
            //do effect transfer here
            throw new NotImplementedException();
        }
    }
}
