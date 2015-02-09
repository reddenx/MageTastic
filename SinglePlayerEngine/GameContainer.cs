using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SinglePlayerEngine.Services;
using SinglePlayerEngine.GameState;

namespace SinglePlayerEngine
{
    class GameContainer : Game
    {
        private GraphicsDeviceManager GraphicsDeviceManager;
        private readonly Point ScreenDimensions = new Point(1024, 768);

        //gamestate nonsense
        private GameStateBase CurrentGameState;
        private LoadingState LoadingState;
        private GameStateBase AsyncPendingGameState;

        public GameContainer()
            :base()
        {
            ConsoleService.Initialize();//very first thing

            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Assets";

            GraphicsDeviceManager.PreferredBackBufferWidth = ScreenDimensions.X;
            GraphicsDeviceManager.PreferredBackBufferHeight = ScreenDimensions.Y;

            GraphicsDeviceManager.SynchronizeWithVerticalRetrace = true;
        }

        protected override void Initialize()
        {
            InputService.Initialize();
            WorldService.Initialize();
            ContentService.Initialize();
            RenderService.Initialize(ScreenDimensions);
            UIService.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            RenderService.SetupRenderer(GraphicsDevice);
            ContentService.LoadContent(Content);

            //build loading state and switch to it
            LoadingState = new LoadingState(null);
            LoadingState.StartupSynchronous(Content);
            CurrentGameState = LoadingState;

            var mainMenu = new MainMenuState(this);
            mainMenu.StartupAsync(Content,
                () =>
                {
                    CurrentGameState = mainMenu;
                });

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            ContentService.UnloadContent(Content);
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            InputService.Update(gameTime);
            ConsoleService.Update(gameTime);
            CurrentGameState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            CurrentGameState.Draw(gameTime);
            ConsoleService.Draw(gameTime);
            base.Draw(gameTime);
        }

        public void ChangeState(GameStateBase newState)
        {
            ConsoleService.RecordInfo(string.Format("State change from {0} to {1}", CurrentGameState.GetType().ToString(), newState.GetType().ToString()));

            if (AsyncPendingGameState != null)
            {
                ConsoleService.RecordCriticalEvent("Gamestate transition error, the pending state is not done loading");
            }

            var oldState = CurrentGameState;
            AsyncPendingGameState = newState;
            CurrentGameState = LoadingState;
            oldState.ShutdownAsync(Content, 
                () => 
                {
                    AsyncPendingGameState.StartupAsync(Content, 
                        () =>
                        {
                            CurrentGameState = AsyncPendingGameState;
                            AsyncPendingGameState = null;
                        });
                });
        }
    }
}
