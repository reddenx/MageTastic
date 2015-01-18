using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SinglePlayerEngine.Entities.Brains;
using SinglePlayerEngine.Entities.Physics;

namespace SinglePlayerEngine.Entities
{
    class Entity
    {
        public BrainComponent Brain;
        public PhysicsComponent Physics;
        public Dictionary<EntityAction, Animation> AnimationSet;
        public Texture2D Texture;

        public void Update(GameTime gameTime)
        {
            Brain.Update(gameTime);
            Physics.Update(gameTime);
        }
    }
}
