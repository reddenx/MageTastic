using MageTastic.Engines;
using MageTastic.Entities.Characters;
using MageTastic.Entities.Characters.Enemies;
using MageTastic.Entities.Characters.Skills;
using MageTastic.Entities.Projectiles;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.CharacterStates.SkillStates
{
    class EnemyShootOrb : CharacterStateBase
    {
        private readonly CharacterStateBase PreviousState;
        private readonly TickTimer ShootTime;
        private readonly SkillBase SkillUsed;

        public override EntityState CurrentState
        {
            get { return EntityState.Attacking; }
        }

        public EnemyShootOrb(CharacterStateBase previousState, SkillBase usedSkill)
            : base(previousState)
        {
            PreviousState = previousState;
            ShootTime = new TickTimer(1000);
            SkillUsed = usedSkill;
        }

        private void CreateAndShootOrb()
        {
            var enemy = CharacterContext as ProtoEnemy;
            var direction = enemy.Target.Position - Context.Position;
            direction.Normalize();
            direction *= 1.5f;

            var flyTime = 900;

            WorldEngine.AddEntityToWorld(new ProjectileProtoBlueOrb(
                Assets.BlueMagicProjectileAnimationSet,
                Assets.BlueMagicProjectile,
                CurrentFrame.LeftAttach + Context.Position - Context.State.CurrentFrame.Origin,
                direction,
                flyTime,
                SkillUsed));
        }

        public override void HandleMovement(Vector2 movementVector)
        {
            movementVector.Normalize();
            movementVector /= 10f;

            Context.Position += movementVector;
            base.HandleMovement(movementVector);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);

            ShootTime.Update(gameTime);
            if (ShootTime.IsComplete)
            {
                CreateAndShootOrb();
                ChangeState(PreviousState);
            }
        }
    }
}
