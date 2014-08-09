using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.PlayerStateMachine
{
    /// <summary>
    /// Entity died, hangs out here until removed from
    /// world or resurrected.
    /// 
    /// can go to idle if brought back to life
    /// </summary>
    class Dead : CharacterStateBase
    {
        public override EntityStates CurrentState
        {
            get { return EntityStates.Dead; }
        }

        public Dead(CharacterStateBase oldState)
            : base(oldState)
        { }
    }
}
