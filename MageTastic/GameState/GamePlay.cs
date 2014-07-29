using MageTastic.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MageTastic.Utility;
using MageTastic.Entities;
using Microsoft.Xna.Framework.Input;
using MageTastic.Engines;

namespace MageTastic.GameState
{
    class GamePlay : GameStateBase
    {
        private Level CurrentLevel;

        public GamePlay()
        {
            CurrentLevel = new Level();
        }

        public override void Initialize()
        {
            //TODO remove proto code
            CurrentLevel.AddEntity(new PlayerProto());
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
                RenderEngine.RenderTransform);

            CurrentLevel.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
