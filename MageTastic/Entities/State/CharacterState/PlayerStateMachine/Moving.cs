using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.PlayerStateMachine
{
    class Moving : StateBase
    {
        public override EntityStates CurrentState
        {
            get { return EntityStates.Moving; }
        }

        public Moving(StateBase oldState)
            : base(oldState)
        { }

        public override void HandleMovement(Vector2 movementVector)
        {
            if (movementVector == Vector2.Zero)
            {
                ChangeState(new Idle(this));
                return;
            }

            Context.Position += movementVector;
        }
    }
}
