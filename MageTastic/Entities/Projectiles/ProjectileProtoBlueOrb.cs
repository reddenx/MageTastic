using MageTastic.Engines;
using MageTastic.Entities.Characters;
using MageTastic.Entities.Characters.Skills;
using MageTastic.Entities.States;
using MageTastic.Entities.States.ProjectileStates;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.Projectiles
{
    class ProjectileProtoBlueOrb : ProjectileBase
    {
        public SkillBase Source;
        public Vector2 Velocity;

        public ProjectileProtoBlueOrb(Dictionary<EntityState, EntityFrame[][]> animationSet, Texture2D texture, Vector2 position, Vector2 velocity, int flyTime, SkillBase source)
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
        }

        public override void HandleCollision(Entity colliders)
        {
            //TODO do effect transfer here?
        }
    }
}
