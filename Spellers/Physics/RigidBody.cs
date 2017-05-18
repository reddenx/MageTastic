using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.Physics
{
    class RigidBody
    {
        public Vector2 Position;
        public float Width;
        public float Height;
        public float Rotation;

        public RigidBody(Vector2 position, float width, float height, float rotation)
        {
            this.Position = position;
            this.Width = width;
            this.Height = height;
            this.Rotation = rotation;
        }

        //these could use calculation dirty bits for efficiency
        public Vector2 GetTopLeft()
        {
            return new Vector2(Position.X - (0.5f * Width), Position.Y - (0.5f * Height)).RotatePoint(Position, Rotation);
        }

        public Vector2 GetTopRight()
        {
            return new Vector2(Position.X + (0.5f * Width), Position.Y - (0.5f * Height)).RotatePoint(Position, Rotation);
        }

        public Vector2 GetBottomRight()
        {
            return new Vector2(Position.X + (0.5f * Width), Position.Y + (0.5f * Height)).RotatePoint(Position, Rotation);
        }

        public Vector2 GetBottomLeft()
        {
            return new Vector2(Position.X - (0.5f * Width), Position.Y + (0.5f * Height)).RotatePoint(Position, Rotation);
        }

        public float GetCollisionRadius()
        {
            return Vector2.Distance(GetTopLeft(), Position);
        }
    }
}
