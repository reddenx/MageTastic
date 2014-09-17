using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MageTastic.Entities;
using Microsoft.Xna.Framework;
using MageTastic.Engines;
using Microsoft.Xna.Framework.Input;

namespace MageTastic.Utility
{
    class Camera
    {
        private Vector2 Position;
        private Point ViewDimensions;
        public float Zoom { get; private set; }
        private Entity Target;
        public Matrix Transformation
        {
            get { return Matrix.CreateScale(Zoom) * Matrix.CreateTranslation(new Vector3(Position, 0f)); }
        }

        public Camera(Point screenDimensions)
        {
            Target = null;
            ViewDimensions = screenDimensions;
            Zoom = 6.0f;
        }

        public void Update(GameTime gameTime)
        {
            if (InputEngine.WasKeyPressed(Keys.OemPlus))
            {
                Zoom = Zoom + 1 < 6 ? Zoom + 1 : 6;
            }
            else if (InputEngine.WasKeyPressed(Keys.OemMinus))
            {
                Zoom = Zoom - 1 > 1 ? Zoom - 1 : 1;
            }

            if (Target != null)
            {
                Position = -Target.Position * Zoom + new Vector2(ViewDimensions.X / 2, ViewDimensions.Y / 2);// new Vector2(Target.Position.X - ViewDimensions.X / 2, Target.Position.Y - ViewDimensions.Y / 2);
            }
        }

        public void SetTarget(Entity target)
        {
            Target = target;
        }

        public Vector2 TranslateToWorldSpace(Point windowsSpace)
        {
            return (new Vector2(windowsSpace.X, windowsSpace.Y) - Position) / Zoom;
        }

        public Rectangle GetWorldlyViewport()
        {
            var transPosition = Position * -1 / Zoom;
            var transDimensions = new Point((int)(ViewDimensions.X / Zoom), (int)(ViewDimensions.Y / Zoom));
            return new Rectangle((int)transPosition.X, (int)transPosition.Y, transDimensions.X, transDimensions.Y);
        }
    }
}
