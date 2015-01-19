using Microsoft.Xna.Framework;
using SinglePlayerEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePlayerEngine.Entities.Brains
{
    class PlayerBrain : BrainComponent
    {
        public PlayerBrain(Entity context)
            :base(context)
        {
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Vector2 movementDirection = Vector2.Zero;
            
            if (InputService.IsKeyHeld(ActionDefinitions.Player1MoveDown))
            {
                movementDirection += new Vector2(0, 1);
            }

            if (InputService.IsKeyHeld(ActionDefinitions.Player1MoveUp))
            {
                movementDirection += new Vector2(0, -1);
            }

            if (InputService.IsKeyHeld(ActionDefinitions.Player1MoveLeft))
            {
                movementDirection += new Vector2(-1, 0);
            }

            if (InputService.IsKeyHeld(ActionDefinitions.Player1MoveRight))
            {
                movementDirection += new Vector2(1, 0);
            }

            Context.Physics.SetMovementDirection(movementDirection);
        }
    }
}
