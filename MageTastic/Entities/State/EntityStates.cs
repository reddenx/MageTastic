using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Entities.State
{
    enum EntityStates
    {
        //dev
        Vitruvian = 0,

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

    enum Direction
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }

    static class DirectionExtensions
    {
        public static Direction ToDirection(this Vector2 vector)
        {
            if (Math.Abs(vector.X) > Math.Abs(vector.Y))
            {
                if (vector.X > 0)
                {
                    return Direction.Right;
                }
                else
                {
                    return Direction.Left;
                }
            }
            else
            {
                if (vector.Y > 0)
                {
                    return Direction.Down;
                }
                else
                {
                    return Direction.Up;
                }
            }
        }
    }
}
