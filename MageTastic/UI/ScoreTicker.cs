using MageTastic.Engines;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.UI
{
    class ScoreTicker : ControlBase
    {
        private Vector2 Position;

        public ScoreTicker()
        {
            Position = new Vector2(10, 10);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Assets.DevFont, "Score: " + WorldEngine.LevelDirector.Score.ToString(), Position, Color.Red, 0f, Vector2.Zero, 2f, SpriteEffects.None, 1f);
        }
    }
}
