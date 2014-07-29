using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Utility
{
    static class VectorExtensions
    {
        public static Vector2 ToVector(this Point p)
        {
            return new Vector2(p.X, p.Y);
        }
    }
}
