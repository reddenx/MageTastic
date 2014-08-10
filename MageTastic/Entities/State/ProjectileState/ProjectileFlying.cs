using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.ProjectileState
{
    //TODO this is a proto, make into generic projectile
    class ProjectileFlying : AnimatedStateBase
    {
        private ProjectileProtoBlueOrb Projectile { get { return (ProjectileProtoBlueOrb)Context; } }

        public ProjectileFlying(ProjectileProtoBlueOrb context)
            : base(context)
        {
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            Projectile.Position += Projectile.Velocity;
        }

        public override EntityStates CurrentState
        {
            get { return EntityStates.Vitruvian; }
        }
    }
}
