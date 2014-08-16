using MageTastic.Entities.Characters.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.CharacterStates.EnemyStates
{
    class IdleEnemy : AnimatedStateBase
    {
        public override EntityState CurrentState
        {
            get { return EntityState.Idle; }
        }

        public IdleEnemy(ProtoEnemy enemy)
            : base(enemy)
        { }
    }
}
