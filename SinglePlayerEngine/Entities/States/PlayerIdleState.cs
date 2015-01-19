using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePlayerEngine.Entities.States
{
    class PlayerIdleState : EntityStateBase
    {
        public PlayerIdleState(Entity context)
            : base(context)
        { }

        public PlayerIdleState(EntityStateBase previousState)
            : base(previousState)
        { }

        public override EntityAction GetEntityAction()
        {
            return EntityAction.Idle;
        }
    }
}
