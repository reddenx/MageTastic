﻿using MageTastic.World;
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
            WorldEngine.SetLevel(CurrentLevel);
        }

        public override void Initialize()
        {
            //TODO remove proto code
            var player = new PlayerProto(new Vector2(2000));
            CurrentLevel.AddEntity(player);

            RenderEngine.SetCameraTarget(player);
            
            NetworkEngine.StartHosting();
            //NetworkEngine.ConnectTo("192.168.10.150");
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
