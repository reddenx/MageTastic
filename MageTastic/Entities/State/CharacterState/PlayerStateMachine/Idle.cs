using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.PlayerStateMachine
{
    class Idle : CharacterStateBase
    {
        public override EntityStates CurrentState
        {
            get { return EntityStates.Idle; }
        }

        public Idle(Character context)
            : base(context)
        { }

        public Idle(CharacterStateBase oldState)
            :base(oldState)
        {
        }

        public override void HandleMovement(Vector2 movementVector)
        {
            if (movementVector != Vector2.Zero)
            {
                ChangeState(new Moving(this));
            }
        }
    }
}
