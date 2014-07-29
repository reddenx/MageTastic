using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MageTastic.Utility
{
    static class RectangleExtensions
    {
        public static void CenterOnPosition(this Rectangle rect, Vector2 vector)
        {
            rect.X = (int)(vector.X - rect.Width / 2);
            rect.Y = (int)(vector.Y - rect.Height / 2);
        }
    }
}
