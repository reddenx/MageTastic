using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SMCEngine.Entities;

namespace SMCEngine.Services
{
    public class WorldService
    {
        private static WorldService Instance;

        private WorldService() { }

        public void Instantiate()
        {
            if (Instance != null)
            {
                throw new InvalidOperationException("Already Instantiated");
            }

            Instance = new WorldService();
        }

        public Entity[] QueryWorld(Rectangle query)
        {
            throw new NotImplementedException();
        }

        public Entity[] QueryWorld(Vector2 position, float radius)
        {
            throw new NotImplementedException();
        }

        public void SpawnEntity(Entity entity)
        {
            throw new NotImplementedException();    
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
