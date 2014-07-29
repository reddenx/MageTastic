using MageTastic.Engines;
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
                return base.State.CurrentFrame;
            }
        }

        public PlayerProto()
        //:base(collisionBoxDimensions, boundingBoxDimensions, origin, texture, position)
        {
            State = new EntityState(Assets.KnightAnimationSet);
            Position = Vector2.Zero;
            Texture = Assets.PlayerKnight;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //set update parameters from input
            var movementDirection = GetMovementDirectionFromKeyboard();
            var facingDirection = GetFacingDirectionFromMouse();

            //move player
            Position += movementDirection;

            State.Update(gameTime, facingDirection, EntityStates.Moving);
        }

        private Direction GetFacingDirectionFromMouse()
        {
            var facingDirection = RenderEngine.TranslateWindowsToWorldSpace(Mouse.GetState().Position) - Position;

            if (Math.Abs(facingDirection.X) > Math.Abs(facingDirection.Y))
            {
                if (facingDirection.X > 0)
                {
                    return Direction.Right;
                }
                else
                {
                    return Direction.Left;
                }
            }
            else
            {
                if (facingDirection.Y > 0)
                {
                    return Direction.Down;
                }
                else
                {
                    return Direction.Up;
                }
            }
        }

        private Vector2 GetMovementDirectionFromKeyboard()
        {
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

            return movementInputDirection;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            RenderEngine.DrawPlayerProto(spriteBatch, this);

            spriteBatch.DrawString(
                Assets.DevFont,
                Mouse.GetState().Position.X + "," + Mouse.GetState().Position.Y,
                Vector2.Zero,
                Color.Black);
        }

        public override void HandleCollision(Entity colliders)
        {
            throw new NotImplementedException();
        }
    }
}
