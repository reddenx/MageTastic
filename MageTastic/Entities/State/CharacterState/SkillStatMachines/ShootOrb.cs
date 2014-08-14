using MageTastic.Engines;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.SkillStatMachines
{
    class ShootOrb : CharacterStateBase
    {
        private readonly CharacterStateBase ReturnState;

        private Random Rand = new Random();

        private TickTimer InternalStateTimer;

        public override EntityState CurrentState
        {
            get { return EntityState.Attacking; }
        }

        public ShootOrb(CharacterStateBase previousState, CharacterStateBase returnState)
            : base(previousState)
        {
            ReturnState = returnState;
            InternalStateTimer = TickTimer.Expired;
        }

        public override void Update(GameTime gameTime)
        {
            InternalStateTimer.Update(gameTime);
            if (InternalStateTimer.IsComplete )
            {
                CreateAndShootOrb();

                if (InputEngine.IsKeyUp(Keys.Space))
                {
                    ChangeState(ReturnState);
                }
                else
                {
                    InternalStateTimer = new TickTimer(250);
                }
            }

            base.Update(gameTime);
        }

        private void CreateAndShootOrb()
        {
            var direction = RenderEngine.TranslateWindowsToWorldSpace(Mouse.GetState().Position) - Context.Position;
            direction.Normalize();
            direction += (new Vector2((float)Rand.NextDouble(), (float)Rand.NextDouble()) - new Vector2(.5f)) * .5f;
            direction.Normalize();
            direction *= 1f;

            var flyTime = Rand.Next(900, 1200);

            WorldEngine.AddEntityToWorld(new ProjectileProtoBlueOrb(
                Assets.BlueMagicProjectileAnimationSet,
                Assets.BlueMagicProjectile,
                CurrentFrame.LeftAttach + Context.Position - Context.State.CurrentFrame.Origin,
                direction,
                flyTime,
                Context as Character));
        }

        public override void HandleMovement(Vector2 movementVector)
        {
            Context.Position += movementVector * 0.2f;
        }
    }
}
