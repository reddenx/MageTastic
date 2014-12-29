using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMCEngine.Entities
{
    public enum EntityActions
    {
        Vitruvian = 0,
        Idle = 1,
        Moving = 2,
        Dead = 3,

        Recoiling = 4,
        Stunned = 5,

        Preparing = 6,
        Attacking = 7,
        Recovering = 8,
    }

    public enum EntityDirections
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 4,
    }
}
