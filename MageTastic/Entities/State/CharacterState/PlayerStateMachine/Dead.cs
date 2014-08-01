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
    class Dead : StateBase
    {
        public Dead(StateBase oldState)
            : base(oldState)
        { }

        public override EntityStates CurrentState
        {
            get { throw new NotImplementedException(); }
        }
    }
}
