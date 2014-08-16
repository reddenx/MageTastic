using MageTastic.Engines;
using MageTastic.Entities.Characters.Skills;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.CharacterStates.SkillStates
{
    class ChargeOrb : CharacterStateBase
    {
        private readonly CharacterStateBase ReturnState;
        private readonly SkillBase SkillUsed;

        private TickTimer InternalStateTimer;

        public override EntityState CurrentState
        {
            get { return EntityState.ChargingUp; }
        }

        public ChargeOrb(CharacterStateBase returnState, SkillBase usedSkill)
            : base(returnState)
        {
            SkillUsed = usedSkill;
            ReturnState = returnState;
            InternalStateTimer = new TickTimer(1000);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            InternalStateTimer.Update(gameTime);
            if (InternalStateTimer.IsComplete)
            {
                ChangeState(new ShootOrb(this, ReturnState, SkillUsed));
            }

            base.Update(gameTime);
        }
    }
}
