using MageTastic.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState
{
    abstract class CharacterStateBase : AnimatedStateBase
    {
        protected Character CharacterContext { get { return (Character)Context; } } //safe cast cause we know it's a character

        protected CharacterStateBase(CharacterStateBase oldBase) 
            :base(oldBase)
        { }

        public CharacterStateBase(Character context)
            :base(context)
        {
        }
    }
}
