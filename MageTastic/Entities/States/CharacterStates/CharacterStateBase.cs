using MageTastic.Entities.Characters;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.CharacterStates
{
    abstract class CharacterStateBase : AnimatedStateBase
    {
        private AnimationContainer AnimationLeft;
        public EntityFrame CurrentLeftFrame { get { return AnimationLeft.CurrentFrame; } }

        protected Character CharacterContext { get { return (Character)Context; } } //safe cast cause we know it's a character

        protected CharacterStateBase(CharacterStateBase oldBase)
            : base(oldBase)
        {
            AnimationLeft = new AnimationContainer(CharacterContext.LeftHand.AnimationSet[CurrentState]);
        }

        public CharacterStateBase(Character context)
            : base(context)
        {
            AnimationLeft = new AnimationContainer(CharacterContext.LeftHand.AnimationSet[CurrentState]);
        }

        public override void Update(GameTime gameTime)
        {
            AnimationLeft.Update(gameTime, CurrentDirection);
            base.Update(gameTime);
        }

    }
}
