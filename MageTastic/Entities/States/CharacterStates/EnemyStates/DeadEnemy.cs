using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.CharacterStates.EnemyStates
{
    class DeadEnemy : AnimatedStateBase
    {
        public DeadEnemy(AnimatedStateBase oldBase)
            :base(oldBase)
        {
        }

        public override EntityState CurrentState
        {
            get { return EntityState.Dead; }
        }
    }
}
