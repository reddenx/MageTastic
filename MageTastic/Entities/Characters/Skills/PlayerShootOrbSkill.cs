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
        public PlayerShootOrbSkill(Character owner)
            :base(owner)
        {

        }

        public override CharacterStateBase GetStartingSkillState(CharacterStateBase previousState)
        {
            return new ChargeOrb(previousState, this);
        }

        public override SkillEffect[] Effects
        {
            get
            {
                return new SkillEffect[] { new BlueOrbEffect(Owner) };
            }
        }
    }
}
