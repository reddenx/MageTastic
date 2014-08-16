using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.CharacterStates.PlayerStates
{
    /// <summary>
    /// Entity died, hangs out here until removed from
    /// world or resurrected.
    /// 
    /// can go to idle if brought back to life
    /// </summary>
    class DeadPlayer : CharacterStateBase
    {
        public override EntityState CurrentState
        {
            get { return EntityState.Dead; }
        }

        public DeadPlayer(CharacterStateBase oldState)
            : base(oldState)
        { }
    }
}
