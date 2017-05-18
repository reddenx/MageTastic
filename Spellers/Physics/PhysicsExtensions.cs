using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.Physics
{
    static class PhysicsExtensions
    {
        public static Vector2 RotatePoint(this Vector2 position, Vector2 pivotAround, float rotation)
        {
            var x = (float)(pivotAround.X + (position.X - pivotAround.X) * Math.Cos(rotation) - (position.Y - pivotAround.Y) * Math.Sin(rotation));
            var y = (float)(pivotAround.Y + (position.Y - pivotAround.Y) * Math.Cos(rotation) + (position.X - pivotAround.X) * Math.Sin(rotation));
            return new Vector2(x, y);
        }
    }
}
