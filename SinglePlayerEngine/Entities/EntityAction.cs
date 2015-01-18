using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglePlayerEngine.Entities
{
    enum EntityAction
    {
        Vitruvian,

        Idle,
        Moving,
        Dead,

        Casting,
        Channelling,
        Recovering,

        Stunned,
    }

    enum EntityFacingDirections
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
    }
}
