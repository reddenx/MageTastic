using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Entities.State
{
    class EntityStateManager
    {
        private readonly Entity Entity;
        private EntityStates CurrentState;

        public EntityStateManager(Entity entity)
        {
            Entity = entity;
        }

        public void SetState(EntityStates state)
        {
            
        }
    }
}
