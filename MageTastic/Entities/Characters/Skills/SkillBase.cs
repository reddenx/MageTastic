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
    abstract class SkillBase
    {
        //some sort of cooldown timer
        public TickTimer CooldownTimer;

        public SkillBase()
        {}

        abstract public CharacterStateBase GetStartingSkillState(CharacterStateBase previousState);

        public void StartCooldown()
        {
            CooldownTimer = new TickTimer(5000);
        }
    }
}
