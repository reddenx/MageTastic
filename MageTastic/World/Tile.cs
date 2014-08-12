using MageTastic.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.World
{
    class Tile
    {
        public readonly Texture2D Texture;
        public readonly Rectangle SourceRectangle;
        public readonly Rectangle DrawRectangle;

        public Tile(Texture2D texture, Rectangle sourceRectangle, Rectangle drawRectangle)
        {
            Texture = texture;
            SourceRectangle = sourceRectangle;
            DrawRectangle = drawRectangle;
        }
    }
}
