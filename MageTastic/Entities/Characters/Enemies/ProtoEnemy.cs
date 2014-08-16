using MageTastic.Engines;
using MageTastic.Entities.States;
using MageTastic.Entities.States.CharacterStates.EnemyStates;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.Characters.Enemies
{
    class ProtoEnemy : Character
    {
        public ProtoEnemy(Dictionary<EntityState,EntityFrame[][]> animationSet, Texture2D texture, Vector2 position)
            : base(animationSet, texture, position, EntityTeam.Enemies)
        {
            State = new IdleEnemy(this);
            Stats = new CharacterStats(this);
        }

        public override void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            RenderEngine.DrawPlayerProto(spriteBatch, this);

            spriteBatch.DrawString(Assets.DevFont, Stats.Health.ToString(), Position, Color.Black);
        }

        public override void HandleCollision(Entity colliders)
        {
        }

        public override void OnDeath()
        {
            State = new DeadEnemy(State);
        }
    }
}
