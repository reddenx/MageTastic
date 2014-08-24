using MageTastic.Entities.Characters.Skills;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States
{
    abstract class AnimatedStateBase
    {
        abstract public EntityState CurrentState { get; }
        protected Entity Context;

        private AnimationContainer Animation;

        public EntityFrame CurrentFrame { get { return Animation.CurrentFrame; } }
        public Direction CurrentDirection { get; protected set; }

        private AnimatedStateBase() { }

        protected AnimatedStateBase(AnimatedStateBase oldBase) 
        {
            Context = oldBase.Context;
            CurrentDirection = oldBase.CurrentDirection;

            Animation = new AnimationContainer(Context.AnimationSet[CurrentState]);
        }

        public AnimatedStateBase(Entity context)
        {
            Context = context;

            Animation = new AnimationContainer(Context.AnimationSet[CurrentState]);
            CurrentDirection = Direction.Up;
        }

        protected void ChangeAnimation(EntityState state)
        {
            Animation = new AnimationContainer(Context.AnimationSet[state]);

        }

        public virtual void Update(GameTime gameTime)
        {
            Animation.Update(gameTime, CurrentDirection);
        }

        //inputs into state machine
        public virtual void HandleHitBy(object skillOrAttackIwasHitBy) { }
        public virtual void HandleMovement(Vector2 movementVector) { }
        public virtual void HandleAction(SkillBase actionInput) { }
        public virtual void ChangeDirection(Direction direction) { CurrentDirection = direction; }
        public virtual void HandleCollision(Entity collider) { Context.HandleCollision(collider); }

        protected void ChangeState(AnimatedStateBase newState)
        {
            Context.State = newState;
        }
    }
}
