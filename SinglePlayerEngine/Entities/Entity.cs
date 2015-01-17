using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePlayerEngine.Entities
{
    class Entity
    {
        public PhysicsComponent Physics;
        public Animation CurrentAnimation;
        public Dictionary<EntityAction, Animation> AnimationSet;
    }
}
