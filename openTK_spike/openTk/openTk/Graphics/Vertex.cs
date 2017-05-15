using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openTk.Graphics
{
    struct Vertex
    {
        public const int Size = (3 + 4) * 4;

        public Vector3 Position;
        public Color4 Color;

        public Vertex(Vector3 position, Color4 color)
        {
            this.Position = position;
            this.Color = color;
        }
    }
}
