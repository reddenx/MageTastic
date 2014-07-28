using MageTastic.Entities.State;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Entities
{
    class PlayerProto : Entity
    {
        public override EntityFrame CurrentStateFrame
        {
            get
            {
                return new EntityFrame(
                    new Point(8, 8),
                    new Rectangle(1, 1, 5, 5),
                    new Vector2(5, 5),
                    new Vector2(8, 4),
                    new Vector2(8, 4),
                    null,
                    null,
                    null,
                    100);
            }
        }

        public PlayerProto()
        //:base(collisionBoxDimensions, boundingBoxDimensions, origin, texture, position)
        {
            Position = Vector2.Zero;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //get movement direction from wasd
            var movementInputDirection = Vector2.Zero;
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A))
            {
                movementInputDirection.X -= 1;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                movementInputDirection.X += 1;
            }

            if (keyboardState.IsKeyDown(Keys.W))
            {
                movementInputDirection.Y -= 1;
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                movementInputDirection.Y += 1;
            }

            if (movementInputDirection != Vector2.Zero)
            {
                movementInputDirection.Normalize();
            }

            //move player
            Position += movementInputDirection;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            var sourceRectangle = new Rectangle(0, 0, 8, 8);

            spriteBatch.Draw(
                Assets.PlayerKnight,
                Position - CurrentStateFrame.Origin,
                sourceRectangle,
                Color.White);
        }

        public override void HandleCollision(Entity colliders)
        {
            throw new NotImplementedException();
        }
    }
}
