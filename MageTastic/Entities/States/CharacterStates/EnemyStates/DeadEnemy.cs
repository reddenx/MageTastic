using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.CharacterStates.EnemyStates
{
    class DeadEnemy : CharacterStateBase
    {
        public DeadEnemy(CharacterStateBase oldBase)
            :base(oldBase)
        {
            Context.IsCollidable = false;
        }

        public override EntityState CurrentState
        {
            get { return EntityState.Dead; }
        }
    }
}
