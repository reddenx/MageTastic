using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SinglePlayerEngine.Services
{
    class ContentService
    {
        private static ContentService Instance;

        public static Texture2D DevTexture;
        public static Texture2D BlueMagicProjectile;

        internal static void Initialize()
        {
            Instance = new ContentService();
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

            BlueMagicProjectile = SafeLoadTexture("BlueMagicProjectile", content);
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
    }
}
