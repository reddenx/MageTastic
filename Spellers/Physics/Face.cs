using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.Physics
{
    class Face
    {
        public Vector2 Start;
        public Vector2 End;

        public Face(Vector2 start, Vector2 end)
        {
            this.Start = start;
            this.End = end;
        }

        public Vector2 GetNormal()
        {
            var direction = End - Start;
            return new Vector2(direction.Y, -direction.X);
        }
    }
}
