using MageTastic.Entities.Characters;
using MageTastic.Entities.Characters.Skills;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.CharacterStates.PlayerStates
{
    class IdlePlayer : CharacterStateBase
    {
        public override EntityState CurrentState
        {
            get { return EntityState.Idle; }
        }

        public IdlePlayer(Character context)
            : base(context)
        { }

        public IdlePlayer(CharacterStateBase oldState)
            :base(oldState)
        {
        }

        public override void HandleAction(SkillBase actionInput)
        {
            ChangeState(actionInput.GetStartingSkillState(this));
        }

        public override void HandleMovement(Vector2 movementVector)
        {
            if (movementVector != Vector2.Zero)
            {
                ChangeState(new MovingPlayer(this));
            }
        }
    }
}
