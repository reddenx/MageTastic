using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SinglePlayerEngine.Entities;
using Microsoft.Xna.Framework;

namespace SinglePlayerEngine.Services
{
    class ContentService
    {
        private static ContentService Instance;

        public static Texture2D DevTexture;
        public static SpriteFont DevFont { get; set; }

        public static Texture2D BlueMagicProjectileTexture;
        public static Dictionary<EntityAction, Animation> BlueMagicProjectileAnimations;


        internal static void Initialize()
        {
            Instance = new ContentService();
            ConsoleService.RecordInfo("Content Service Initialized");
        }

        private ContentService()
        { }

        public static void LoadContent(ContentManager content)
        {
            Instance.LoadContentFiles(content);
        }

        public static void UnloadContent(ContentManager Content)
        {
        }

        private void LoadContentFiles(ContentManager content)
        {
            DevTexture = content.Load<Texture2D>("Dev");
            DevFont = content.Load<SpriteFont>("DevFont");

            BlueMagicProjectileTexture = SafeLoadTexture("BlueMagicProjectile", content);
            BlueMagicProjectileAnimations = SafeLoadAnimation("BlueMagicProjectileAnimations.txt");
        }

        private Texture2D SafeLoadTexture(string name, ContentManager content)
        {
            try
            {
                return content.Load<Texture2D>(name);
            }
            catch
            {
                ConsoleService.RecordError("Could not find resource: " + name);
            }

            return DevTexture;
        }

        private Dictionary<EntityAction, Animation> SafeLoadAnimation(string name)
        {
            //TODO hardcoded
            return new Dictionary<EntityAction, Animation>()
            {
                { EntityAction.Idle , new Animation(new EntityAnimationFrame[] 
                    {
                        new EntityAnimationFrame()
                        {
                            FrameTime = 250,
                            Origin = Vector2.Zero,
                            SourceRectangle = new Rectangle(0,0,8,8),
                        }
                    })
                },
            };
        }

        public static void LoadMainMenuContent()
        {
        }

    }
}
