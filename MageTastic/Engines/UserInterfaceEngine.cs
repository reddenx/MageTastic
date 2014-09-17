using MageTastic.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Engines
{
    /// <summary>
    /// this is every static control on screen, dynamic controls are handled in world
    /// </summary>
    class UserInterfaceEngine
    {
        private static UserInterfaceEngine Instance;

        private List<ControlBase> Controls;

        private UserInterfaceEngine()
        {
            Controls = new List<ControlBase>();
        }

        public static void Initialize()
        {
            if (Instance == null)
            {
                Instance = new UserInterfaceEngine();
            }
        }

        public static void Reinitialize()
        {
            Instance = new UserInterfaceEngine();
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var control in Instance.Controls)
            {
                control.Update(gameTime);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var control in Instance.Controls)
            {
                control.Draw(spriteBatch);
            }
        }

        public static void RegisterControl(object control)
        {

        }
    }
}
