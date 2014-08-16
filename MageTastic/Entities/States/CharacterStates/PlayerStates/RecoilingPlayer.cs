using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.CharacterStates.PlayerStates
{
    /// <summary>
    /// happens when hit by a skill or attack
    /// that makes you flinch or recoil,
    /// generally can't move
    /// 
    /// can go to stunned or to idle
    /// </summary>
    class RecoilingPlayer : CharacterStateBase
    {
        public override EntityState CurrentState
        {
            get { return EntityState.Recoiling; }
        }

        public RecoilingPlayer(CharacterStateBase oldState, int timeMilli)
            : base(oldState)
        { }
    }
}
