using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.CharacterStates.EnemyStates
{
    class MovingEnemy : CharacterStateBase
    {
        public override EntityState CurrentState
        {
            get { return EntityState.Moving; }
        }

        public MovingEnemy(CharacterStateBase oldBase)
            : base(oldBase)
        {
        }

        public override void HandleMovement(Vector2 movementVector)
        {
            Context.Acceleration += movementVector;
        }

        public override void HandleAction(Characters.Skills.SkillBase actionInput)
        {
            ChangeState(actionInput.GetStartingSkillState(this));
        }
    }
}
