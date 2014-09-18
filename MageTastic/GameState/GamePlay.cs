using MageTastic.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MageTastic.Utility;
using MageTastic.Entities;
using MageTastic.Engines;
using MageTastic.Entities.Characters.Players;
using MageTastic.Entities.Characters.Enemies;

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
            WorldEngine.Instantiate();
            WorldEngine.SetLevel(CurrentLevel);
            var player = WorldEngine.CreatePlayerProto();
            RenderEngine.SetCameraTarget(player);

            //TODO somehow pivot off hosting
            NetworkEngine.StartSinglePlayer();
            //NetworkEngine.StartHosting();
            //NetworkEngine.ConnectTo("192.168.10.150");
        }

        public override void TearDown()
        {
            WorldEngine.UnInstantiate();
            NetworkEngine.CleanUp();
        }

        public override void Update(GameTime gameTime)
        {
            CurrentLevel.Update(gameTime);
            UserInterfaceEngine.Update(gameTime);
            RenderEngine.Update(gameTime);
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

            spriteBatch.Begin();

            UserInterfaceEngine.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
