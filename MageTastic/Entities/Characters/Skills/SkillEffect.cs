﻿using System;
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
        protected readonly Character Owner;

        abstract public void ApplyTo(Character receiver);

        public SkillEffect(Character owner, DamageTypes damageType)
        {
            DamageType = damageType;
            Owner = owner;
        }

        public static float GetModifierForResistance(int resistance)
        {
            var resMax = .9f;
            var defScale = 1f;

            var modifier = (1 - (1 - 1 / ((float)resistance / defScale + 1)) * resMax);//TODO algebra fail, simplify this

            return modifier;
        }

        public static float GetModifierForDamage(int skill)
        {
            return 1f; //TODO skills: still undecided on this one, probably just gonna be linear
        }
    }
}
