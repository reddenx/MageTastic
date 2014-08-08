using MageTastic.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.SkillStatMachines
{
    class ShootOrb : CharacterStateBase
    {
        private readonly CharacterStateBase ReturnState;

        private TickTimer InternalStateTimer;

        private EntityStates CurrentSkillState;
        public override EntityStates CurrentState
        {
            get { return CurrentSkillState; }
        }

        public ShootOrb(CharacterStateBase returnState)
            :base(returnState)
        {
            CurrentSkillState = EntityStates.ChargingUp;
            ReturnState = returnState;
            InternalStateTimer = new TickTimer(1000);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            InternalStateTimer.Update(gameTime);
            if (InternalStateTimer.IsComplete )
            {
                if (CurrentSkillState == EntityStates.ChargingUp)
                {
                    CurrentSkillState = EntityStates.Attacking;
                }
            }

            base.Update(gameTime);
        }
    }
}
