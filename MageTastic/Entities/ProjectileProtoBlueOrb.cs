using MageTastic.Engines;
using MageTastic.Entities.State;
using MageTastic.Entities.State.ProjectileState;
using MageTastic.Utility;
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
        public Character Source;
        public Vector2 Velocity;

        public ProjectileProtoBlueOrb(Dictionary<EntityState, EntityFrame[][]> animationSet, Texture2D texture, Vector2 position, Vector2 velocity, int flyTime, Character source)
            :base(animationSet, texture, true, position)
        {
            Velocity = velocity;
            State = new BlueOrbFlyingProto(this, flyTime);
            Source = source;
        }

        public override void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            RenderEngine.DrawProjectileProto(spriteBatch, this);

            var color = Color.White;
            color.A = 150;

            spriteBatch.Draw(Assets.DevTexture, GetTranslatedPhysicsRectangle(), color);
        }

        public override void HandleCollision(Entity colliders)
        {
            //do effect transfer here
             //throw new NotImplementedException();
        }
    }
}
