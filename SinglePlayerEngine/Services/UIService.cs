using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SinglePlayerEngine.UI;

namespace SinglePlayerEngine.Services
{
    class UIService
    {
        private static UIService Instance;

        private List<UIElement> Elements;

        public static void Initialize()
        {
            Instance = new UIService();
        }

        private UIService()
        {
            Elements = new List<UIElement>();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var element in Instance.Elements)
            {
                element.Draw(spriteBatch);
            }
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var element in Instance.Elements)
            {
                element.Update(gameTime);
            }

            Instance.Elements.RemoveAll(element => element.IsDead);
        }

        public static void AddElement(UIElement element)
        {
            Instance.Elements.Add(element);
        }
    }
}
