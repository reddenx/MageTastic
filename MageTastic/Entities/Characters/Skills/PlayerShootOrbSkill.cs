using MageTastic.Entities.States.CharacterStates;
using MageTastic.Entities.States.CharacterStates.SkillStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.Characters.Skills
{
    class PlayerShootOrbSkill : SkillBase
    {
        public PlayerShootOrbSkill() { }

        public override CharacterStateBase GetStartingSkillState(CharacterStateBase previousState)
        {
            return new ChargeOrb(previousState);
        }
    }
}
