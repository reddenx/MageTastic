using MageTastic.Engines;
using MageTastic.Entities.Characters.Skills;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.Projectiles
{
    abstract class ProjectileBase : Entity
    {
        public SkillBase Source;
        public Vector2 Direction;

        public ProjectileBase(Dictionary<EntityState, EntityFrame[][]> animationSet, Texture2D texture, bool isCollidable, Vector2 position, Vector2 velocity, SkillBase source)
            : base(animationSet, texture, isCollidable, position)
        {
            Velocity = velocity;
            Direction = velocity;
            Source = source;
        }

        public override void Update(GameTime gameTime)
        {
            State.Update(gameTime);

            Position += Velocity;
            //base.Update(gameTime);
        }

        public override void HandleCollision(Entity colliders)
        { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            RenderEngine.DrawProjectile(spriteBatch, this);
        }
    }
}
