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
        abstract public SkillEffect[] Effects { get; }
        public readonly Character Owner;

        public SkillBase(Character owner)
        {
            Owner = owner;
        }

        abstract public CharacterStateBase GetStartingSkillState(CharacterStateBase previousState);
    }
}
