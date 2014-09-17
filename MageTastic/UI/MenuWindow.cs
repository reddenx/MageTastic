using MageTastic.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.UI
{
    class MenuWindow : ControlBase
    {
        private List<ControlBase> Controls;
        private readonly Texture2D Texture;
        private readonly int Padding;

        public MenuWindow(ControlBase[] controls, int padding = 10)
        {
            Controls = new List<ControlBase>(controls);
            Padding = padding;
            Texture = Assets.MenuBackground;
        }

        private void BuildLayout()
        {
            var height = (int)(((Bounds.Bottom - Padding) - (Bounds.Top + Padding)) / Controls.Count);
            var width = (Bounds.Right - Padding) - (Bounds.Left + Padding);
            var top = (Bounds.Top + Padding);
            var left = (Bounds.Left + Padding);

            foreach (var control in Controls)
            {
                control.Bounds = new Rectangle(top, left, width, height);
                top += height;
            }
        }
        
        public override void Update(GameTime gameTime)
        {
            foreach (var control in Controls)
            {
                control.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var control in Controls)
            {
                control.Draw(spriteBatch);
            }
        }
    }
}
