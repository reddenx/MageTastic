using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.UI
{
    abstract class ControlBase
    {
        virtual public void Update(GameTime gameTime) { }
        virtual public void Draw(SpriteBatch spriteBatch) { }
        public Rectangle Bounds;
    }
}
