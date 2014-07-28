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

        public void DetermineCollisions()
        {
            //stupidly inefficient n^2(ish) algorithm
            foreach (var entity in Entities)
            {
                if (entity.IsCollidable)
                {
                    foreach (var check in Entities)
                    {
                        if (check.IsCollidable && entity.CurrentStateFrame.PhysicsBox.Intersects(check.CurrentStateFrame.PhysicsBox))
                        {
                            check.HandleCollision(entity);
                            entity.HandleCollision(check);
                        }
                    }
                }
            }
        }
    }
}
