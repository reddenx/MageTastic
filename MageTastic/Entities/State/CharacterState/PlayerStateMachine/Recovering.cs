using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.PlayerStateMachine
{
    /// <summary>
    /// Post attack recovery
    /// 
    /// automatically goes to idle once finished
    /// can go to recoiling
    /// </summary>
    class Recovering : StateBase
    {
        public Recovering(StateBase oldBase)
            : base(oldBase)
        { }

        public override EntityStates CurrentState
        {
            get { throw new NotImplementedException(); }
        }
    }
}
