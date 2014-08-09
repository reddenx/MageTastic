using MageTastic.Entities.State;
using MageTastic.Utility.Parsing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Utility
{
    class Assets
    {
        private static Assets Instance;


        public static SpriteFont DevFont;

        public static Texture2D DevTexture;
        public static Texture2D PlayerKnight;
        public static Texture2D BlueMagicProjectile;
        public static Dictionary<EntityStates, EntityFrame[][]> CharacterAnimationSet;
        public static Dictionary<EntityStates, EntityFrame[][]> BlueMagicProjectileAnimationSet;

        private Assets()
        {
            CharacterAnimationSet = ParsingUtils.GetAnimationSetFromFile("Assets\\Hero_1aData.txt");
            BlueMagicProjectileAnimationSet = ParsingUtils.GetAnimationSetFromFile("Assets\\BlueMagicProjectileData.txt");
        }

        public static void Initialize()
        {
            if (Instance == null)
            {
                Instance = new Assets();
            }
        }

        public static void LoadContent(ContentManager content)
        {
            Instance._LoadContent(content);
        }

        private void _LoadContent(ContentManager content)
        {
            //this one better load ^_^
            DevTexture = content.Load<Texture2D>("Dev");
            DevFont = content.Load<SpriteFont>("arial");

            PlayerKnight = LoadTextureFallWithFallback("Hero_1a", content);
            BlueMagicProjectile = LoadTextureFallWithFallback("BlueMagicProjectile", content);
        }

        private Texture2D LoadTextureFallWithFallback(string textureName, ContentManager content)
        {
            try
            {
                return content.Load<Texture2D>(textureName);
            }
            catch
            {
                return DevTexture;
            }
        }
    }
}
