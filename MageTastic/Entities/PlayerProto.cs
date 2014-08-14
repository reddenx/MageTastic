using MageTastic.Engines;
using MageTastic.Entities.State;
using MageTastic.Entities.State.CharacterState;
using MageTastic.Entities.State.CharacterState.PlayerStateMachine;
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
    class PlayerProto : Character
    {
        private SkillProto ProtoSkill;

        public PlayerProto(Vector2 position)
            :base(Assets.CharacterAnimationSet, Assets.PlayerKnight, position, EntityTeam.Players)
        {
            ProtoSkill = new SkillProto();
            State = new Idle(this);
        }

        public override void Update(GameTime gameTime)
        {
            //set update parameters from input
            var movementDirection = GetMovementDirectionFromKeyboard();
            var facingDirection = RenderEngine.TranslateWindowsToWorldSpace(Mouse.GetState().Position) - Position;

            State.ChangeDirection(facingDirection.ToDirection());
            State.HandleMovement(movementDirection);

            State.Update(gameTime);
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

            if (InputEngine.WasKeyPressed(Keys.Space))
            {
                UseSkill(ProtoSkill);
            }

            return movementInputDirection;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            RenderEngine.DrawPlayerProto(spriteBatch, this);

            //spriteBatch.Draw(Assets.DevTexture, new Rectangle((int)Position.X, (int)Position.Y, 1,1), Color.White);
            //spriteBatch.Draw(Assets.DevTexture, new Rectangle((int)(State.CurrentFrame.LeftAttach.X + Position.X - State.CurrentFrame.Origin.X), (int)(State.CurrentFrame.LeftAttach.Y + Position.Y - State.CurrentFrame.Origin.Y), 1, 1), Color.White);
            //spriteBatch.Draw(Assets.DevTexture, new Rectangle((int)(State.CurrentFrame.RightAttach.X + Position.X - State.CurrentFrame.Origin.X), (int)(State.CurrentFrame.RightAttach.Y + Position.Y - State.CurrentFrame.Origin.Y), 1, 1), Color.White);

            //RenderEngine.DrawDevDot(spriteBatch, Position);
            //RenderEngine.DrawDevDot(spriteBatch, Position + State.CurrentFrame.RightAttach - State.CurrentFrame.Origin);

            spriteBatch.DrawString(
                Assets.DevFont,
                State.ToString(),
                Vector2.Zero,
                Color.Black,
                0f,
                Vector2.Zero,
                .2f,
                SpriteEffects.None,
                0f);
        }

        public override void HandleCollision(Entity colliders)
        {
            //if it's a skill collision, notify the state and let it handle it
            //throw new NotImplementedException();
        }
    }
}
