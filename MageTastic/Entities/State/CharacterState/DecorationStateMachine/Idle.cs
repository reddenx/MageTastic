﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.State.CharacterState.DecorationStateMachine
{
    /// <summary>
    /// decorations hang out but don't interact or do anything
    /// </summary>
    class Idle : CharacterStateBase
    {
        private Idle(Character context)
            :base(context)
        { }

        public override EntityStates CurrentState
        {
            get { return EntityStates.Idle; }
        }
    }
}
