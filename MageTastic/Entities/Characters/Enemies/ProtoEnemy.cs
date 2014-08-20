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
using MageTastic.Entities.States.CharacterStates;

namespace MageTastic.Entities.Characters.Enemies
{
    class ProtoEnemy : Character
    {
        public Character Target;
        private SkillBase Skill;

        private Vector2 FlockVariation;
        private TickTimer FlockVariationTimer;

        public ProtoEnemy(Dictionary<EntityState,EntityFrame[][]> animationSet, Texture2D texture, Vector2 position)
            : base(animationSet, texture, position, EntityTeam.Enemies, new CharacterAttachment(Assets.HammerAnimationSet, Assets.HammerTexture))
        {
            State = new IdleEnemy(this);
            Stats = new CharacterStats(this);
            FlockVariationTimer = new TickTimer(5000);
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
                movementDirection = Target.Position - Position + FlockVariation;
                movementDirection.Normalize();
                movementDirection /= 2;

                State.ChangeDirection((Target.Position - Position).ToDirection());
                State.HandleMovement(movementDirection);

                //attack until target is dead
                if ((Position - Target.Position).Length() < 50)
                {
                    State.HandleAction(Skill);
                }
            }
            //acquire new target if they're dead

            //setup flock variations
            FlockVariationTimer.Update(gameTime);
            if (FlockVariationTimer.IsComplete)
            {
                FlockVariationTimer.Reset(WorldEngine.Rand.Next(3000,5000));
                FlockVariation = new Vector2(WorldEngine.Rand.Next(-100, 100), WorldEngine.Rand.Next(-100, 100));
            }

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
            State = new DeadEnemy(State as CharacterStateBase);
        }
    }
}
