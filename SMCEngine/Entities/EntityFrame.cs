using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMCEngine.Entities
{
    public class EntityFrame
    {
        public Rectangle SourceRectangle;

        public Rectangle[] CollisionRectangles;
        public Rectangle[] DamageRectangles;
    }
}
