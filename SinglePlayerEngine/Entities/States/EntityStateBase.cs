using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePlayerEngine.Entities.States
{
    abstract class EntityStateBase
    {
        protected Entity Context;
        private Animation CurrentAnimation;

        protected EntityStateBase(Entity context)
        {
            Context = context;
            CurrentAnimation = Context.AnimationSet[GetEntityAction()];
        }

        public EntityStateBase(EntityStateBase previousState)
        {
            var currentAction = GetEntityAction();

            if (currentAction != previousState.GetEntityAction())
            {
                CurrentAnimation = Context.AnimationSet[currentAction];
            }
            else
            {
                CurrentAnimation = previousState.CurrentAnimation;
                CurrentAnimation.Reset();
            }
        }

        public EntityAnimationFrame GetCurrentFrame()
        {
            return CurrentAnimation.GetCurrentFrame();
        }

        public abstract EntityAction GetEntityAction();
    }
}
