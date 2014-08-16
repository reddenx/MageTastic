using MageTastic.Entities.Projectiles;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.ProjectileStates
{
    class BlueOrbExplosionProto : AnimatedStateBase
    {
        private ProjectileProtoBlueOrb Projectile { get { return (ProjectileProtoBlueOrb)Context; } }
        private TickTimer ExplosionTimer;

        public BlueOrbExplosionProto(AnimatedStateBase oldState)
            :base(oldState)
        {
            ExplosionTimer = new TickTimer(750);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ExplosionTimer.Update(gameTime);
            if (ExplosionTimer.IsComplete)
            {
                Context.RemoveFromWorld = true;
            }
        }

        public override EntityState CurrentState
        {
            get { return EntityState.Attacking; }
        }
    }
}
