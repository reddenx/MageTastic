using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.GameState
{
    class GameObject : Game
    {
        private readonly GraphicsDeviceManager GraphicsDeviceManager;
        private readonly SpriteBatch SpriteBatch;

        public GameObject()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Assets";
            
            GraphicsDeviceManager.PreferredBackBufferWidth = 1024;
            GraphicsDeviceManager.PreferredBackBufferHeight = 768;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            base.Initialize();
            //non content based loading (startup network here)
        }

        protected override void LoadContent()
        {
            //build up assets
        }

        protected override void UnloadContent()
        {
            //unload content
        }
    }
}
