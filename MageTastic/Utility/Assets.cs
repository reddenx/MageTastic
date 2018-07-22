using MageTastic.Entities;
using MageTastic.Entities.States;
using MageTastic.Utility.Parsing;
using MageTastic.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static Texture2D TileMapTexture;
        public static Texture2D HammerTexture;
        public static Texture2D MenuBackground;

        public static Dictionary<EntityState, EntityFrame[][]> CharacterAnimationSet;
        public static Dictionary<EntityState, EntityFrame[][]> BlueMagicProjectileAnimationSet;
        public static Dictionary<EntityState, EntityFrame[][]> HammerAnimationSet;
        public static Rectangle[][][] BlendedTileSet;
        public static Tile[,] LevelOneTileMap { get; set; }

        private Assets()
        {
            CharacterAnimationSet = ParsingUtils.GetAnimationSetFromFile("Assets\\Hero_1aData.txt");
            BlueMagicProjectileAnimationSet = ParsingUtils.GetAnimationSetFromFile("Assets\\BlueMagicProjectileData.txt");
            HammerAnimationSet = ParsingUtils.GetAnimationSetFromFile("Assets\\HammerData.txt");

            BlendedTileSet = ParsingUtils.GetTileSetFromFile("Assets\\BlendedTileSetData.txt");
        }

        public static void Initialize()
        {
            if (Instance == null)
            {
                Instance = new Assets();
            }
        }

        public static void LoadContent(ContentManager content, GraphicsDeviceManager gdm)
        {
            Instance._LoadContent(content, gdm);
        }

        private void _LoadContent(ContentManager content, GraphicsDeviceManager gdm)
        {
            //this one better load ^_^
            using (var fstream = new FileStream("./Assets/Dev.png", FileMode.Open))
                DevTexture = Texture2D.FromStream(gdm.GraphicsDevice, fstream);

            DevFont = content.Load<SpriteFont>("arial");

            PlayerKnight = LoadTextureFallWithFallback("./Assets/Hero_1a.png", gdm);
            BlueMagicProjectile = LoadTextureFallWithFallback("./Assets/BlueMagicProjectile.png", gdm);
            TileMapTexture = LoadTextureFallWithFallback("./Assets/OutdoorTileset.png", gdm);
            HammerTexture = LoadTextureFallWithFallback("./Assets/Hammer.png", gdm);
            MenuBackground = LoadTextureFallWithFallback("./Assets/MenuBackground.png", gdm);

            LevelOneTileMap = ParsingUtils.GetLevelFromImage("Assets\\Island.png");
        }

        private Texture2D LoadTextureFallWithFallback(string textureName, GraphicsDeviceManager gdm)
        {
            try
            {
                using (var fstream = new FileStream(textureName, FileMode.Open))
                    return Texture2D.FromStream(gdm.GraphicsDevice, fstream);
            }
            catch
            {
                return DevTexture;
            }
        }


    }
}
