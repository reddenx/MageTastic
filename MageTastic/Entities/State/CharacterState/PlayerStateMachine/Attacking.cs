using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.PlayerStateMachine
{
    /// <summary>
    /// This is where the attack happens
    /// 
    /// automatically goes to recovering,
    /// can go to recoiling
    /// </summary>
    class Attacking : StateBase
    {
        public override EntityStates CurrentState
        {
            get { throw new NotImplementedException(); }
        }
    }
}
