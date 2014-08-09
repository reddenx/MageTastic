using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.ProjectileState
{
    //TODO this is a proto, make into generic projectile
    class ProjectileFlying : AnimatedStateBase
    {
        protected ProjectileProtoBlueOrb Projectile;

        public ProjectileFlying(ProjectileProtoBlueOrb context)
            : base(context)
        {
        }

        public override EntityStates CurrentState
        {
            get { return EntityStates.Vitruvian; }
        }
    }
}
