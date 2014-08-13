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
            WorldEngine.SetLevel(CurrentLevel);
        }

        public override void Initialize()
        {
            //TODO remove proto code
            var player = new PlayerProto();
            CurrentLevel.AddEntity(player);
            var enemy = new ProtoEnemy(Assets.CharacterAnimationSet, Assets.PlayerKnight, new Vector2(100, 100));
            CurrentLevel.AddEntity(enemy);
            

            RenderEngine.SetCameraTarget(player);
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

            //TODO dev dots
            var mousePos = RenderEngine.TranslateWindowsToWorldSpace(Mouse.GetState().Position);
            spriteBatch.Draw(Assets.DevTexture, new Rectangle((int)mousePos.X, (int)mousePos.Y, 1, 1), Color.White);

            spriteBatch.End();
        }
    }
}
