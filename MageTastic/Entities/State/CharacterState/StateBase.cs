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
        protected PlayerProto Context;

        //think this is a powerful pattern, publicly need to supply context, internally handles automatically with changestate
        protected StateBase() { } 

        public StateBase(PlayerProto context)
        {
            Context = context;
        }

        //inputs into state machine
        public virtual void HandleHitBy(object skillOrAttackIwasHitBy) { }
        public virtual void HandleMovement(Vector2 movementVector) { }
        public virtual void HandleAction(object actionInput) { }

        protected void ChangeState(StateBase newState)
        {
            newState.Context = Context;
            Context.CharacterFSM = newState;
        }
    }
}
