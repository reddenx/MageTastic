using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.PlayerStateMachine
{
    /// <summary>
    /// The state before an attack or skill happens,
    /// like a casting time or windup
    /// 
    /// automatically goes to attacking
    /// can go to recoiling, or back to idle if cancellable
    /// </summary>
    class Charging : StateBase
    {
        public Charging(StateBase oldState)
            : base(oldState)
        { }

        public override EntityStates CurrentState
        {
            get { throw new NotImplementedException(); }
        }
    }
}
