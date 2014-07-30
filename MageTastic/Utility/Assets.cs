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

        public static Texture2D PlayerKnight;
        public static Dictionary<EntityStates, EntityFrame[][]> KnightAnimationSet;

        private Assets()
        {
            KnightAnimationSet = ParsingUtils.GetAnimationSetFromFile("Assets\\stateTemplate.txt");
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
            PlayerKnight = content.Load<Texture2D>("Template");
            DevFont = content.Load<SpriteFont>("arial");
        }

        //TODO remove proto code
        private Dictionary<EntityStates, EntityFrame[][]> ProtoBuildWalking()
        {
            var animation = new Dictionary<EntityStates, EntityFrame[][]>();

            var movingFrames = new EntityFrame[][]
            {
                new EntityFrame[]
                {
                    new EntityFrame(
                        new Point(8,8),
                        new Rectangle(1,1,5,7),
                        new Vector2(2.5f, 4),
                        new Vector2(8,4),
                        new Vector2(1,4),
                        null,
                        null,
                        null,
                        new Rectangle(0,8,8,8),
                        125),
                    new EntityFrame(
                        new Point(8,8),
                        new Rectangle(1,1,5,7),
                        new Vector2(2.5f, 4),
                        new Vector2(8,4),
                        new Vector2(1,4),
                        null,
                        null,
                        null,
                        new Rectangle(8,8,8,8),
                        125)
                },
                new EntityFrame[]
                {
                    new EntityFrame(
                        new Point(8,8),
                        new Rectangle(1,1,5,7),
                        new Vector2(2.5f, 4),
                        new Vector2(8,4),
                        new Vector2(1,4),
                        null,
                        null,
                        null,
                        new Rectangle(0,16,8,8),
                        125),
                    new EntityFrame(
                        new Point(8,8),
                        new Rectangle(1,1,5,7),
                        new Vector2(2.5f, 4),
                        new Vector2(8,4),
                        new Vector2(1,4),
                        null,
                        null,
                        null,
                        new Rectangle(8,16,8,8),
                        125)
                },
                new EntityFrame[]
                {
                    new EntityFrame(
                        new Point(8,8),
                        new Rectangle(1,1,5,7),
                        new Vector2(2.5f, 4),
                        new Vector2(8,4),
                        new Vector2(1,4),
                        null,
                        null,
                        null,
                        new Rectangle(0,24,8,8),
                        125),
                    new EntityFrame(
                        new Point(8,8),
                        new Rectangle(1,1,5,7),
                        new Vector2(2.5f, 4),
                        new Vector2(8,4),
                        new Vector2(1,4),
                        null,
                        null,
                        null,
                        new Rectangle(8,24,8,8),
                        125)
                },
                new EntityFrame[]
                {
                    new EntityFrame(
                        new Point(8,8),
                        new Rectangle(1,1,5,7),
                        new Vector2(2.5f, 4),
                        new Vector2(8,4),
                        new Vector2(1,4),
                        null,
                        null,
                        null,
                        new Rectangle(0,32,8,8),
                        125),
                    new EntityFrame(
                        new Point(8,8),
                        new Rectangle(1,1,5,7),
                        new Vector2(2.5f, 4),
                        new Vector2(8,4),
                        new Vector2(1,4),
                        null,
                        null,
                        null,
                        new Rectangle(8,32,8,8),
                        125)
                }
            };

            animation.Add(EntityStates.Moving, movingFrames);

            return animation;
        }
    }
}
