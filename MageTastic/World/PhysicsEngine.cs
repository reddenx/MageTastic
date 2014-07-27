using MageTastic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.World
{
    class PhysicsEngine
    {
        public void DetermineCollisions(List<Entity> entities)
        {
            //stupidly inefficient n^2 algorithm
            foreach (var entity in entities)
            {
                if (entity.IsCollidable)
                {
                    foreach (var check in entities)
                    {
                        if (check.IsCollidable && entity.CollisionBox.Intersects(check.CollisionBox))
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
