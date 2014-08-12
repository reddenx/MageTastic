using MageTastic.Engines;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.SkillStatMachines
{
    class ChargeOrb : CharacterStateBase
    {
        private readonly CharacterStateBase ReturnState;

        private TickTimer InternalStateTimer;

        public override EntityStates CurrentState
        {
            get { return EntityStates.ChargingUp; }
        }

        public ChargeOrb(CharacterStateBase returnState)
            : base(returnState)
        {
            ReturnState = returnState;
            InternalStateTimer = new TickTimer(1000);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            InternalStateTimer.Update(gameTime);
            if (InternalStateTimer.IsComplete)
            {
                ChangeState(new ShootOrb(this, ReturnState));
            }

            base.Update(gameTime);
        }
    }
}
