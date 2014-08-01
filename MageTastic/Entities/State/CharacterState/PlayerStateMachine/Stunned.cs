using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.PlayerStateMachine
{
    /// <summary>
    /// when a skill or attack does stun
    /// it makes you unable to do anything until
    /// the timer or other effect takes you out of
    /// stun
    /// 
    /// can go to idle
    /// </summary>
    class Stunned : StateBase
    {
        public Stunned(StateBase oldState)
            : base(oldState)
        { }

        public override EntityStates CurrentState
        {
            get { throw new NotImplementedException(); }
        }
    }
}
