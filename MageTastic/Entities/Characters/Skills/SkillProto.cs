using MageTastic.Entities.States;
using MageTastic.Entities.States.CharacterStates;
using MageTastic.Entities.States.CharacterStates.SkillStates;
using MageTastic.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.Characters.Skills
{
    class SkillProto
    {
        //needs to somehow kick off the state machine for that direction meaning it must store the initial state

        //some sort of cooldown timer
        public TickTimer CooldownTimer;

        public SkillProto()
        {
        }

        public AnimatedStateBase InitiateSkill(CharacterStateBase previousState)
        {
            var skillStartState = new ChargeOrb(previousState);
            return skillStartState;
        }

        public void StartCooldown()
        {
            CooldownTimer = new TickTimer(5000);
        }
    }
}
