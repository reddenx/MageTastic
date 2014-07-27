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
        public static Texture2D PlayerKnight;
        private static Assets Instance;

        private Assets()
        {
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
            PlayerKnight = content.Load<Texture2D>("PlayerKnight");
        }

    }
}
