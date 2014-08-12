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

        public override EntityStates CurrentState
        {
            get { return EntityStates.Attacking; }
        }

        public ShootOrb(CharacterStateBase previousState, CharacterStateBase returnState)
            : base(previousState)
        {
            ReturnState = returnState;
            InternalStateTimer = new TickTimer(150);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            InternalStateTimer.Update(gameTime);
            if (InternalStateTimer.IsComplete )
            {
                CreateAndShootOrb();

                if (InputEngine.IsKeyUp(Keys.D1))
                {
                    ChangeState(ReturnState);
                }
                else
                {
                    InternalStateTimer = new TickTimer(150);
                }
            }

            base.Update(gameTime);
        }

        private void CreateAndShootOrb()
        {
            var direction = RenderEngine.TranslateWindowsToWorldSpace(Mouse.GetState().Position) - Context.Position;
            direction.Normalize();
            direction += (new Vector2((float)Rand.NextDouble(), (float)Rand.NextDouble()) - new Vector2(.5f)) * .25f;
            direction.Normalize();
            direction *= 1.5f;

            var flyTime = Rand.Next(900, 1200);

            WorldEngine.AddEntityToWorld(new ProjectileProtoBlueOrb(
                Assets.BlueMagicProjectileAnimationSet,
                Assets.BlueMagicProjectile,
                CurrentFrame.LeftAttach + Context.Position - Context.State.CurrentFrame.Origin,
                direction,
                flyTime));
        }

        public override void HandleMovement(Vector2 movementVector)
        {
            Context.Position += movementVector * 0.2f;
        }
    }
}
