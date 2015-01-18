using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SinglePlayerEngine.Utility;

namespace SinglePlayerEngine.Services
{
    class RenderService
    {
        private static RenderService Instance;

        private SpriteBatch SpriteBatch;
        private Camera PlayerCamera;

        public static void Initialize(Point screenSize)
        {
            Instance = new RenderService(screenSize);
        }

        private RenderService(Point screenSize)
        {
            PlayerCamera = new Camera(screenSize, 1f);
        }

        public static void SetupRenderer(GraphicsDevice device)
        {
            Instance.SpriteBatch = new SpriteBatch(device);
        }

        public static void DrawWorld()
        {
            Instance.SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.NonPremultiplied,
                SamplerState.PointWrap,
                DepthStencilState.Default,
                RasterizerState.CullNone,
                null,
                Instance.PlayerCamera.GetTransformMatrix());

            //TODO background tilesets
            WorldService.GetDrawableEntitiesWithin(Instance.PlayerCamera.GetWorldlyViewport());

            Instance.SpriteBatch.End();
        }

        public static void DrawUI()
        {
            Instance.SpriteBatch.Begin();
            
            UIService.Draw(Instance.SpriteBatch);

            Instance.SpriteBatch.End();
        }

        public static void Update(GameTime gameTime)
        {
            Instance.PlayerCamera.Update(gameTime);
        }
    }
}
