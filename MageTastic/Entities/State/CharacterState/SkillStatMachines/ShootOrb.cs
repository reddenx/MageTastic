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

        public override EntityStates CurrentState
        {
            get { return EntityStates.Attacking; }
        }

        public ShootOrb(CharacterStateBase returnState)
            :base(returnState)
        {
            ReturnState = returnState;
            InternalStateTimer = new TickTimer(3000);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            InternalStateTimer.Update(gameTime);
            if (InternalStateTimer.IsComplete )
            {
                //move to attacking phase
                ChangeState(ReturnState);
            }

            base.Update(gameTime);
        }
    }
}
