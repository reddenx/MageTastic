using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SinglePlayerEngine.Utility;
using SinglePlayerEngine.Entities;

namespace SinglePlayerEngine.Services
{
    class RenderService
    {
        private static RenderService Instance;

        private GraphicsDevice Graphics;
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
            Instance.Graphics = device;
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
            var entities = WorldService.GetDrawableEntitiesWithin(Instance.PlayerCamera.GetWorldlyViewport());
            foreach(var entity in entities)
            {
                Instance.DrawEntity(entity);
            }

            Instance.SpriteBatch.End();
        }

        private void DrawEntity(Entity entity)
        {
            var currentFrame = entity.CurrentState.GetCurrentFrame();

            SpriteBatch.Draw(
                entity.Texture, 
                entity.Physics.Position, 
                currentFrame.SourceRectangle, 
                Color.White,
                0f, 
                currentFrame.Origin, 
                new Vector2(1f),
                SpriteEffects.None,
                GetZScaleForEntityPosition(entity.Physics.Position));


        }

        private float GetZScaleForEntityPosition(Vector2 position)
        {
            //TODO for z ordering
            return 0f;
        }

        public static void DrawUI()
        {
            Instance.SpriteBatch.Begin();
            
            UIService.Draw(Instance.SpriteBatch);

            Instance.SpriteBatch.End();
        }

        public static void Clear(Color color)
        {
            Instance.Graphics.Clear(color);
        }

        public static void Update(GameTime gameTime)
        {
            Instance.PlayerCamera.Update(gameTime);
        }
    }
}
