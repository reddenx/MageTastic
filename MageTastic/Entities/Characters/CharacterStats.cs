using MageTastic.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.Characters
{
    class CharacterStats
    {
        public ConstrainedValue Health;
        public ConstrainedValue Resource;

        public float MovementSpeed;
        public int PhysicalResist;
        public int BleedResist;
        public int MagicResist;

        public int Vitality; //health amount

        public int Strength; //physical damage, bleed/physical resistance, stun duration, aim
        public int Magic;    //magic damage, stun/magic/physical resistance
        public int Agility;  //bleed damage/duration, magic/bleed resistance, crit chance/damage, run speed, dodge
        
        public CharacterStats(Character owner, int vitality, int strength, int magic, int agility)
        {
            Vitality = vitality;
            Strength = strength;
            Magic = magic;
            Agility = agility;
            RecalculateStats(owner);
        }

        public void RecalculateStats(Character owner)
        {
            Health = new ConstrainedValue(100, 0, 100, owner.OnDeath);
            Resource = new ConstrainedValue(100, 0, 100);

            MovementSpeed = 1;//TODO calculate stats
            PhysicalResist = 0;
            BleedResist = 0;
            MagicResist = 0;
        }
    }
}
