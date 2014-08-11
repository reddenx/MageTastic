using MageTastic.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.ProjectileState
{
    //TODO this is a proto, make into generic projectile
    class BlueOrbFlyingProto : AnimatedStateBase
    {
        private ProjectileProtoBlueOrb Projectile { get { return (ProjectileProtoBlueOrb)Context; } }

        private TickTimer ExplosionTimer;

        public BlueOrbFlyingProto(ProjectileProtoBlueOrb context, int flyLife)
            : base(context)
        {
            ExplosionTimer = new TickTimer(flyLife);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            Projectile.Position += Projectile.Velocity;

            ExplosionTimer.Update(gameTime);
            if (ExplosionTimer.IsComplete)
            {
                ChangeState(new BlueOrbExplosionProto(this));
            }
        }

        public override EntityStates CurrentState
        {
            get { return EntityStates.Idle; }
        }
    }
}
