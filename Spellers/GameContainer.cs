using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spellers.GameServices;
using Spellers.GameStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers
{
    class GameContainer : Game
    {
        private GraphicsDeviceManager GraphicsDeviceManager;
        private SpriteBatch TempSpritebatch; //this shouldn't live here, move to renderer

        private GameStateBase CurrentState;
        private LoadingGameState LoadingState;

        public GameContainer()
        {
            ConsoleService.Initialize();

            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Assets";

            GraphicsDeviceManager.PreferredBackBufferWidth = 800;
            GraphicsDeviceManager.PreferredBackBufferHeight = 600;
            GraphicsDeviceManager.SynchronizeWithVerticalRetrace = true;
        }

        protected override void Initialize()
        {
            //initialize services

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //set up first gamestate
            LoadingState = new LoadingGameState(ChangeGameStates);
            CurrentState = new MainMenuGameState(ChangeGameStates);

            base.LoadContent();

            CurrentState.Startup();
            LoadingState.Startup();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

        private void ChangeGameStates(GameStateBase newState)
        {
            var bootingState = newState;
            LoadingState.Reactivate();
            CurrentState = LoadingState;
            var task = Task.Run(() =>
            {
                CurrentState.Shutdown();
                CurrentState.Dispose();
                newState.Startup();
                CurrentState = newState;
            });
        }
    }
}
