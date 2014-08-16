using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.CharacterStates.PlayerStates
{
    /// <summary>
    /// when a skill or attack does stun
    /// it makes you unable to do anything until
    /// the timer or other effect takes you out of
    /// stun
    /// 
    /// can go to idle
    /// </summary>
    class StunnedPlayer : CharacterStateBase
    {
        public override EntityState CurrentState
        {
            get { return EntityState.Stunned; }
        }

        public StunnedPlayer(CharacterStateBase oldState)
            : base(oldState)
        { }
    }
}
