using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.PlayerStateMachine
{
    class Idle : StateBase
    {
        public override EntityStates CurrentState
        {
            get { return EntityStates.Idle; }
        }

        public Idle(Entity context)
            : base(context)
        { }

        public Idle(StateBase oldState)
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
