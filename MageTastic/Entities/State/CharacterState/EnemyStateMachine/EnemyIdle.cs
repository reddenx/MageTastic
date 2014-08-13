using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.EnemyStateMachine
{
    class EnemyIdle : AnimatedStateBase
    {
        public override EntityState CurrentState
        {
            get { return EntityState.Idle; }
        }

        public EnemyIdle(ProtoEnemy enemy)
            : base(enemy)
        { }
    }
}
