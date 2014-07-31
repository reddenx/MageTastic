using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.PlayerStateMachine
{
    /// <summary>
    /// happens when hit by a skill or attack
    /// that makes you flinch or recoil,
    /// generally can't move
    /// 
    /// can go to stunned or to idle
    /// </summary>
    class Recoiling : StateBase
    {

        public override EntityStates CurrentState
        {
            get { throw new NotImplementedException(); }
        }
    }
}
