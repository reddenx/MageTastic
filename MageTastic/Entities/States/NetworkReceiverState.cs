using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States
{
    class NetworkReceiverState : AnimatedStateBase
    {
        private EntityState NetworkedEntityState;

        public override EntityState CurrentState
        {
            get { return NetworkedEntityState; }
        }

        public NetworkReceiverState(Entity entity)
            :base(entity)
        {
            NetworkedEntityState = EntityState.Idle;
            ChangeAnimation(NetworkedEntityState);
        }

        public void ChangeAnimationForNetwork(EntityState state)
        {
            ChangeAnimation(state);
        }
    }
}
