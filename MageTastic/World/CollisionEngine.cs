using MageTastic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.World
{
    class CollisionEngine
    {
        private readonly List<Entity> Entities;

        public CollisionEngine(List<Entity> entities)
        {
            Entities = entities;
        }

        
    }
}
