using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.PlayerStateMaching
{
    /// <summary>
    /// can got to stunned, moving, recoiling, or charging up
    /// </summary>
    class Idle : StateBase
    {
        public override EntityStates CurrentState { get { return EntityStates.Idle; } }

        public override void HandleMovement(Vector2 movementVector)
        {
            //
        }
    }
}
