using MageTastic.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MageTastic.Utility;

namespace MageTastic.GameState
{
    class GamePlay : GameStateBase
    {
        private Level CurrentLevel;
        private Camera Camera;

        public GamePlay(Point screenDimensions)
        {
            Camera = new Camera(screenDimensions);
            CurrentLevel = new Level();
        }

        public override void Update(GameTime gameTime)
        {
            CurrentLevel.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.NonPremultiplied,
                SamplerState.PointWrap,
                DepthStencilState.Default,
                RasterizerState.CullNone,
                null,
                Camera.Transformation);

            CurrentLevel.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
