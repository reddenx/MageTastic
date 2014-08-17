using MageTastic.Engines;
using MageTastic.Entities.Characters.Skills;
using MageTastic.Entities.States;
using MageTastic.Entities.States.CharacterStates.EnemyStates;
using MageTastic.Entities.States.CharacterStates.SkillStates;
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
        public Character Target;
        private SkillBase Skill;

        public ProtoEnemy(Dictionary<EntityState,EntityFrame[][]> animationSet, Texture2D texture, Vector2 position)
            : base(animationSet, texture, position, EntityTeam.Enemies, new CharacterAttachment(Assets.HammerAnimationSet, Assets.HammerTexture))
        {
            State = new IdleEnemy(this);
            Stats = new CharacterStats(this);

            Skill = new EnemyShootOrbSkill(this);
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 movementDirection = Vector2.Zero;

            //basic ai:
            //acquire target
            if (Target == null)
            {
                Target = WorldEngine.GetAllPlayers().FirstOrDefault() as Character;
            }
            //move within attack distance of target
            else
            {
                movementDirection = Target.Position - Position;
                movementDirection.Normalize();
                movementDirection /= 2;

                State.ChangeDirection(movementDirection.ToDirection());
                State.HandleMovement(movementDirection);

                //attack until target is dead
                if ((Position - Target.Position).Length() < 50)
                {
                    State.HandleAction(Skill);
                }
            }
            //acquire new target if they're dead

            State.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            RenderEngine.DrawCharacter(spriteBatch, this);
            base.Draw(spriteBatch);
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
