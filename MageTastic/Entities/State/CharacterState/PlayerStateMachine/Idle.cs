using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.PlayerStateMachine
{
    class Idle : CharacterStateBase
    {
        public override EntityState CurrentState
        {
            get { return EntityState.Idle; }
        }

        public Idle(Character context)
            : base(context)
        { }

        public Idle(CharacterStateBase oldState)
            :base(oldState)
        {
        }

        public override void HandleAction(SkillProto actionInput)
        {
            ChangeState(actionInput.InitiateSkill(this));
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
