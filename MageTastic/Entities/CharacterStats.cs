using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities
{
    class CharacterStats
    {
        //purpose: stats determine damage and resistances
        //3 stats
        //strength 
        //magic    magic attack, resource pool, magic resistance
        //agility  speed, dodge, crit, bleed

        public int Vitality;
        public int Vigor;

        public int Strength; //physical damage, blead/physical resistance, stun duration, aim
        public int Magic;    //magic damage, stun/magic/physical resistance
        public int Agility;  //bleed damage/duration, magic/bleed resistance, crit chance/damage, run speed, dodge
    }
}
