using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.PlayerStateMachine
{
    class Moving : CharacterStateBase
    {
        public override EntityState CurrentState
        {
            get { return EntityState.Moving; }
        }

        public Moving(CharacterStateBase oldState)
            : base(oldState)
        { }

        public override void HandleAction(SkillProto actionInput)
        {
            ChangeState(actionInput.InitiateSkill(this));
        }

        public override void HandleMovement(Vector2 movementVector)
        {
            if (movementVector == Vector2.Zero)
            {
                ChangeState(new Idle(this));
                return;
            }

            movementVector.Normalize();
            movementVector *= .75f;

            Context.Position += movementVector;
        }
    }
}
