using MageTastic.Entities;
using MageTastic.Entities.State;
using MageTastic.Utility;
using MageTastic.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Engines
{
    class RenderEngine
    {
        static RenderEngine Instance;

        private readonly Camera Camera;
        public static Matrix RenderTransform
        {
            get { return Instance.Camera.Transformation; }
        }

        private RenderEngine(Camera camera)
        {
            Camera = camera;
        }

        public static void Instantiate(Camera camera)
        {
            if (Instance == null)
            {
                Instance = new RenderEngine(camera);
            }
        }

        public static void Update(GameTime gameTime)
        {
            Instance.Camera.Update(gameTime);
        }

        public static void DrawPlayerProto(SpriteBatch spriteBatch, Character character)
        {
            Instance._DrawPlayerProto(spriteBatch, character);
        }

        private void _DrawPlayerProto(SpriteBatch spriteBatch, Character character)
        {
            var frame = character.State.CurrentFrame;

            spriteBatch.Draw(character.Texture,
                character.Position,
                frame.SpriteSheetSourceRectangle,
                Color.White,
                0f,
                frame.Origin,
                1f,
                SpriteEffects.None,
                0f);
        }

        public static Vector2 TranslateWindowsToWorldSpace(Point windowsSpace)
        {
            return Instance.Camera.TranslateToWorldSpace(windowsSpace);
        }

        public static void DrawProjectileProto(SpriteBatch spriteBatch, ProjectileProtoBlueOrb projectileProtoBlueOrb)
        {
            var frame = projectileProtoBlueOrb.State.CurrentFrame;

            var rotation = (float)Math.Atan2(projectileProtoBlueOrb.Velocity.X, -projectileProtoBlueOrb.Velocity.Y);

            spriteBatch.Draw(projectileProtoBlueOrb.Texture,
                projectileProtoBlueOrb.Position,
                frame.SpriteSheetSourceRectangle,
                Color.White,
                rotation,
                frame.Origin,
                1f,
                SpriteEffects.None,
                0f);
        }

        internal static void DrawTile(SpriteBatch spriteBatch, Tile tile)
        {
            spriteBatch.Draw(tile.Texture, tile.DrawRectangle, tile.SourceRectangle, Color.White);
        }

        public static void DrawDevDot(SpriteBatch spriteBatch, Vector2 position)
        {
            var scale = 1f / (float)Assets.DevTexture.Bounds.Height;

            spriteBatch.Draw(Assets.DevTexture, position, null, Color.White, 0f, new Vector2(.5f), scale, SpriteEffects.None, 0f);
        }

        public static void SetCameraTarget(Entity target)
        {
            Instance.Camera.SetTarget(target);
        }

        
    }
}
