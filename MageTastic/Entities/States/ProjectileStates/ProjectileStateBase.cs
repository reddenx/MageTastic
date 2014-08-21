using MageTastic.Entities.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States
{
    abstract class ProjectileStateBase : AnimatedStateBase
    {
        public ProjectileStateBase(ProjectileStateBase oldState)
            :base(oldState)
        {
        }

        public ProjectileStateBase(ProjectileBase projectile)
            : base(projectile)
        {
        }
    }
}
