using MageTastic.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.CharacterStates.EnemyStates
{
    class DeadEnemy : CharacterStateBase
    {
        private TickTimer RemoveTimer;

        public DeadEnemy(CharacterStateBase oldBase)
            :base(oldBase)
        {
            RemoveTimer = new TickTimer(20000);
            Context.IsCollidable = false;
        }

        public override void Update(GameTime gameTime)
        {
            RemoveTimer.Update(gameTime);
            if (RemoveTimer.IsComplete)
            {
                Context.RemoveFromWorld = true;
            }
            base.Update(gameTime);
        }

        public override EntityState CurrentState
        {
            get { return EntityState.Dead; }
        }
    }
}
