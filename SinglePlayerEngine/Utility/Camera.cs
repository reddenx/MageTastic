using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SinglePlayerEngine.Utility
{
    class Camera
    {
        private Vector2 Position;
        private Point ViewDimensions;
        private float Zoom;

        public Camera(Point screenDimensions, float zoom)
        {
            ViewDimensions = screenDimensions;
            Zoom = zoom;
        }

        public void Update(GameTime gameTime)
        { }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public Vector2 TranslateToWorldSpace(Point uiSpace)
        {
            return (new Vector2(uiSpace.X, uiSpace.Y) - Position) / Zoom;
        }

        public Rectangle GetWorldlyViewport()
        {
            var transPosition = Position * -1 / Zoom;
            var transDimensions = new Point((int)(ViewDimensions.X / Zoom), (int)(ViewDimensions.Y / Zoom));
            return new Rectangle((int)transPosition.X, (int)transPosition.Y, transDimensions.X, transDimensions.Y);
        }

        public Matrix GetTransformMatrix()
        {
            return Matrix.CreateScale(Zoom) * Matrix.CreateTranslation(Position.X, Position.Y, 0f);
        }
    }
}
