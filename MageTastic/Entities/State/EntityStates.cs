using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Entities.State
{
    enum EntityState
    {
        //basics
        Idle = 1,
        Moving = 2,
        Dead = 3,

        //Combat
        Recoiling = 4,
        Stunned = 5,

        //skills
        ChargingUp = 6,
        Attacking = 7,
        Recovering = 8,
    }
}
