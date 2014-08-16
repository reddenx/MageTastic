using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.Characters.Skills
{
    class BlueOrbEffect : SkillEffect
    {
        private readonly float DamageAmount = 10f;

        public BlueOrbEffect(Character owner)
            :base(owner, DamageTypes.Magic)
        { }

        public override void ApplyTo(Character receiver)
        {
            var attackMod = GetModifierForDamage(Owner.Stats.Magic);
            var defenseMod = GetModifierForResistance(receiver.Stats.MagicResist);

            receiver.Stats.Health -= DamageAmount * attackMod * defenseMod;
        }
    }
}
