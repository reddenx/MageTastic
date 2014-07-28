using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MageTastic.Entities;
using Microsoft.Xna.Framework;

namespace MageTastic.Utility
{
    class Camera
    {
        private Vector2 Position;
        private Point ViewDimensions;
        private float Zoom;
        private Entity Target;
        public Matrix Transformation
        {
            get { return Matrix.CreateScale(Zoom) * Matrix.CreateTranslation(new Vector3(Position, 0f)); }
        }

        public Camera(Point screenDimensions)
        {
            Target = null;
            ViewDimensions = screenDimensions;
            Zoom = 6f;
        }

        public void Update(GameTime gameTime)
        {
            if (Target != null)
            {
                Position = new Vector2(Target.Position.X - ViewDimensions.X / 2, Target.Position.Y - ViewDimensions.Y / 2);
            }
        }
    }
}
