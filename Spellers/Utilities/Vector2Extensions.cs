using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers
{
    public static class Vector2Extensions
    {
        public static bool IntersectFast(this Rectangle a, Rectangle b)
        {
            return a.Intersects(b);
            //return (Math.Abs(a.X - b.X) < (a.Width + b.Width) / 2) && (Math.Abs(a.Y - b.Y) < (a.Height + b.Height) / 2);
        }

        public static float Cross(this Vector2 a, Vector2 b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        public static Vector2 Cross(this float a, Vector2 b)
        {
            return new Vector2(-a * b.Y, a * b.X);
        }

        public static float Dot(this Vector2 a, Vector2 b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public static float Squared(this float a)
        {
            return a * a;
        }

        public static Vector2 Unit(this Vector2 v)
        {
            if (v == Vector2.Zero)
                return Vector2.Zero;
            return v / v.Length();
        }

        public static Vector2 RotatePoint(this Vector2 location, Vector2 pivot, float rotation)
        {
            var X = (float)(pivot.X + (location.X - pivot.X) * Math.Cos(rotation) - (location.Y - pivot.Y) * Math.Sin(rotation));
            var Y = (float)(pivot.Y + (location.Y - pivot.Y) * Math.Cos(rotation) + (location.X - pivot.X) * Math.Sin(rotation));
            return new Vector2(X, Y);
        }

        public static Vector2 ProjectOnto(this Vector2 a, Vector2 b)
        {
            return (a.DotProduct(b) / b.DotProduct(b)) * b;
        }

        public static float ProjectOntoScalar(this Vector2 a, Vector2 b)
        {
            return (a.DotProduct(b) / b.DotProduct(b)) * b.Length();
        }

        public static float CrossProduct(this Vector2 a, Vector2 b)
        {
            return (a.X * b.Y) - (a.Y * b.X);
        }

        public static Vector2 CrossProduct(this float s, Vector2 v)
        {
            return new Vector2(-s * v.Y, s * v.X);
        }

        public static Vector2 CrossProduct(this Vector2 v, float s)
        {
            return new Vector2(s * v.Y, -s * v.X);
        }

        public static float DotProduct(this Vector2 a, Vector2 b)
        {
            return (a.X * b.X) + (a.Y * b.Y);
        }
    }
}
