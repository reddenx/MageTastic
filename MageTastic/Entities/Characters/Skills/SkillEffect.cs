using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.Characters.Skills
{
    enum DamageTypes
    {
        Physical,
        Magic,
        Bleed
    }

    abstract class SkillEffect
    {
        private readonly DamageTypes DamageType;

        abstract public void ApplyTo(Character receiver);

        public static float CalculateGivenStats(float damage, Character from, Character to)
        {
            
        }
    }
}
