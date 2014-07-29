﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MageTastic.Utility;
using Microsoft.Xna.Framework.Input;
using MageTastic.Engines;

namespace MageTastic.GameState
{
    class GameObject : Game
    {
        private GraphicsDeviceManager GraphicsDeviceManager;
        private SpriteBatch SpriteBatch;
        private readonly Point ScreenDimensions = new Point(1024, 768);
        

        private GameStateBase CurrentGameState;

        public GameObject()
            :base()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Assets";
            
            GraphicsDeviceManager.PreferredBackBufferWidth = ScreenDimensions.X;
            GraphicsDeviceManager.PreferredBackBufferHeight = ScreenDimensions.Y;
        }

        protected override void Update(GameTime gameTime)
        {
            CurrentGameState.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            CurrentGameState.Draw(SpriteBatch);

            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            Assets.Initialize();
            
            Camera camera = new Camera(ScreenDimensions);
            RenderEngine.Instantiate(camera);

            CurrentGameState = new GamePlay();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Assets.LoadContent(Content);

            CurrentGameState.Initialize();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}
