using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SinglePlayerEngine.Services;

namespace SinglePlayerEngine
{
    class GameContainer : Game
    {
        private GraphicsDeviceManager GraphicsDeviceManager;
        private readonly Point ScreenDimensions = new Point(1024, 768);
        

        public GameContainer()
            :base()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Assets";

            GraphicsDeviceManager.PreferredBackBufferWidth = ScreenDimensions.X;
            GraphicsDeviceManager.PreferredBackBufferHeight = ScreenDimensions.Y;

            GraphicsDeviceManager.SynchronizeWithVerticalRetrace = true;
        }

        protected override void Initialize()
        {
            ConsoleService.Initialize();
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

            //TODO remove this code when done prototyping
            var player = new SinglePlayerEngine.Entities.Entity(ContentService.BlueMagicProjectileTexture, ContentService.BlueMagicProjectileAnimations);
            player.Brain = new SinglePlayerEngine.Entities.Brains.PlayerBrain(player);
            player.Physics = new SinglePlayerEngine.Entities.Physics.MovingPhysicalEntity(Vector2.Zero, Vector2.Zero, new Vector2(8), 600f, 200f);
            player.CurrentState = new SinglePlayerEngine.Entities.States.PlayerIdleState(player);
            WorldService.AddEntity(player);

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
            WorldService.Update(gameTime);
            ConsoleService.Update(gameTime);
            RenderService.Update(gameTime);
            UIService.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            RenderService.DrawWorld();
            RenderService.DrawUI();

            base.Draw(gameTime);
        }
    }
}
