using MageTastic.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState
{
    abstract class StateBase
    {
        //not necessary but useful for debug and tracking
        abstract public EntityStates CurrentState { get; }

        //TODO this will change to inevitable character class
        protected Entity Context;

        //animation information
        public EntityFrame CurrentFrame { get { return Animation[(int)CurrentDirection][FrameIndex]; } }
        private EntityFrame[][] Animation;
        private TickTimer FrameTimer;
        private int FrameIndex;
        protected Direction CurrentDirection;

        //think this is a powerful pattern, publicly need to supply context, internally handles automatically with changestate
        private StateBase() { }

        protected StateBase(StateBase oldBase) 
        {
            Context = oldBase.Context;

            Animation = Context.AnimationSet[CurrentState];
            FrameTimer = TickTimer.Expired;
            FrameIndex = 0;
            CurrentDirection = oldBase.CurrentDirection;
        }

        public StateBase(Entity context)
        {
            Context = context;

            Animation = Context.AnimationSet[CurrentState];
            FrameTimer = TickTimer.Expired;
            FrameIndex = 0;
            CurrentDirection = Direction.Up;
        }

        public void Update(GameTime gameTime)
        {
            FrameTimer.Update(gameTime);
            if (FrameTimer.IsComplete)
            {
                FrameIndex = (FrameIndex + 1) % Animation[(int)CurrentDirection].Length; //looks goofy but it just doesn't let it go out of bounds
                FrameTimer = new TickTimer(CurrentFrame.FrameTime);
            }
        }

        //inputs into state machine
        public virtual void HandleHitBy(object skillOrAttackIwasHitBy) { }
        public virtual void HandleMovement(Vector2 movementVector) { }
        public virtual void HandleAction(object actionInput) { }
        public virtual void ChangeDirection(Direction direction) { CurrentDirection = direction; }

        protected void ChangeState(StateBase newState)
        {
            Context.State = newState;
        }
    }
}
