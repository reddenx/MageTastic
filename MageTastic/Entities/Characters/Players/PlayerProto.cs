using MageTastic.Engines;
using MageTastic.Entities.Characters.Skills;
using MageTastic.Entities.States.CharacterStates;
using MageTastic.Entities.States.CharacterStates.PlayerStates;
using MageTastic.Entities.States.CharacterStates.SkillStates;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Entities.Characters.Players
{
    class PlayerProto : Character
    {
        private SkillBase ProtoSkill;

        public PlayerProto(Vector2 position)
            : base(Assets.CharacterAnimationSet, Assets.PlayerKnight, position, EntityTeam.Players)
        {
            ProtoSkill = new PlayerShootOrbSkill(this);
            State = new IdlePlayer(this);

            Stats.MagicResist = 100;

            LeftHand = new CharacterAttachment(Assets.HammerAnimationSet, Assets.HammerTexture);
        }

        public override void Update(GameTime gameTime)
        {
            //set update parameters from input
            var movementDirection = GetMovementDirectionFromKeyboard();
            var facingDirection = RenderEngine.TranslateWindowsToWorldSpace(InputEngine.MousePositionInWindowsSpace()) - Position;

            if (InputEngine.WasMouseButtonPressed(MouseButtons.Left))
            {
                UseSkill(ProtoSkill);
            }

            if (InputEngine.WasKeyPressed(Keys.OemTilde))
            {
                IsCollidable = !IsCollidable;
            }

            State.ChangeDirection(facingDirection.ToDirection());
            State.HandleMovement(movementDirection);

            State.Update(gameTime);
        }

        private Vector2 GetMovementDirectionFromKeyboard()
        {
            var movementInputDirection = Vector2.Zero;

            if (InputEngine.IsKeyDown(Keys.A))
            {
                movementInputDirection.X -= 1;
            }
            else if (InputEngine.IsKeyDown(Keys.D))
            {
                movementInputDirection.X += 1;
            }

            if (InputEngine.IsKeyDown(Keys.W))
            {
                movementInputDirection.Y -= 1;
            }
            else if (InputEngine.IsKeyDown(Keys.S))
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
            RenderEngine.DrawCharacter(spriteBatch, this);

            //spriteBatch.Draw(Assets.DevTexture, new Rectangle((int)Position.X, (int)Position.Y, 1,1), Color.White);
            //spriteBatch.Draw(Assets.DevTexture, new Rectangle((int)(State.CurrentFrame.LeftAttach.X + Position.X - State.CurrentFrame.Origin.X), (int)(State.CurrentFrame.LeftAttach.Y + Position.Y - State.CurrentFrame.Origin.Y), 1, 1), Color.White);
            //spriteBatch.Draw(Assets.DevTexture, new Rectangle((int)(State.CurrentFrame.RightAttach.X + Position.X - State.CurrentFrame.Origin.X), (int)(State.CurrentFrame.RightAttach.Y + Position.Y - State.CurrentFrame.Origin.Y), 1, 1), Color.White);

            //RenderEngine.DrawDevDot(spriteBatch, Position);
            //RenderEngine.DrawDevDot(spriteBatch, Position + State.CurrentFrame.RightAttach - State.CurrentFrame.Origin);

            base.Draw(spriteBatch);
        }

        public override void HandleCollision(Entity colliders)
        {
            //if it's a skill collision, notify the state and let it handle it
            //throw new NotImplementedException();
        }

        public override void OnDeath()
        {
            State = new DeadPlayer(State as CharacterStateBase);
        }
    }
}
