using MageTastic.Entities;
using MageTastic.Entities.Characters;
using MageTastic.Entities.Projectiles;
using MageTastic.Entities.States;
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

        private Random Rand;

        private RenderEngine(Camera camera)
        {
            Camera = camera;
            Rand = new Random();
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

        public static void DrawCharacter(SpriteBatch spriteBatch, Character character)
        {
            Instance._DrawCharacter(spriteBatch, character);
        }

        private void _DrawCharacter(SpriteBatch spriteBatch, Character character)
        {
            var frame = character.State.CurrentFrame;

            spriteBatch.Draw(character.Texture,
                character.Position,
                frame.SpriteSheetSourceRectangle,
                Color.White,
                0f,
                frame.Origin,
                frame.Scale,
                SpriteEffects.None,
                0f);

            if (character.LeftHand != null)
            {
                var leftHandFrame = character.LeftHand.AnimationSet[character.State.CurrentState][(int)character.State.CurrentDirection][0];//TODO arg, this needs an animated state machine too

                spriteBatch.Draw(character.LeftHand.Texture,
                    character.Position + frame.LeftAttach - frame.Origin,
                    leftHandFrame.SpriteSheetSourceRectangle,
                    Color.White,
                    0f,
                    leftHandFrame.Origin,
                    leftHandFrame.Scale,
                    SpriteEffects.None,
                    0f);
            }
           
        }

        public static Vector2 TranslateWindowsToWorldSpace(Point windowsSpace)
        {
            return Instance.Camera.TranslateToWorldSpace(windowsSpace);
        }

        public static void DrawProjectile(SpriteBatch spriteBatch, ProjectileBase projectileProtoBlueOrb)
        {
            var frame = projectileProtoBlueOrb.State.CurrentFrame;
            var rotation = (float)Math.Atan2(projectileProtoBlueOrb.Velocity.X, -projectileProtoBlueOrb.Velocity.Y);

            spriteBatch.Draw(projectileProtoBlueOrb.Texture,
                projectileProtoBlueOrb.Position,
                frame.SpriteSheetSourceRectangle,
                Color.White,
                rotation,
                frame.Origin,
                frame.Scale,
                SpriteEffects.None,
                0f);
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

        public static void DrawTileMapInView(Tile[,] tileMap, SpriteBatch spriteBatch)
        {
            var viewpoint = Instance.Camera.GetWorldlyViewport();

            var xMin = viewpoint.X / 16 - 0;
            var yMin = viewpoint.Y / 16 - 0;

            var xMax = viewpoint.Width / 16 + 2 + xMin;
            var yMax = viewpoint.Height / 16 + 1 + yMin;

            for (int y = yMin; y < yMax ; ++y)
            {
                for (int x = xMin; x < xMax ; ++x)
                {
                    var tile = tileMap[x,y];
                    spriteBatch.Draw(tile.Texture, tile.DrawRectangle, tile.SourceRectangle, Color.White);
                }
            }
        }
    }
}
