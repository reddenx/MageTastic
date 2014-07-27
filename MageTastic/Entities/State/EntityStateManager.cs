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
        private EntityState CurrentState;

        public EntityStateManager(Entity entity)
        {
            Entity = entity;
        }

        public void SetState(EntityState state)
        {
            
        }
    }
}
