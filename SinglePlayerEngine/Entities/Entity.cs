using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SinglePlayerEngine.Entities.Brains;
using SinglePlayerEngine.Entities.Physics;
using SinglePlayerEngine.Entities.States;

namespace SinglePlayerEngine.Entities
{
    class Entity
    {
        public BrainComponent Brain;
        public PhysicsComponent Physics;
        public Dictionary<EntityAction, Animation> AnimationSet;
        public Texture2D Texture;

        public EntityStateBase CurrentState;

        public Entity(Texture2D texture, Dictionary<EntityAction, Animation> animationSet)
        {
            Texture = texture;
            AnimationSet = animationSet;
        }

        public void Update(GameTime gameTime)
        {
            Brain.Update(gameTime);
            Physics.Update(gameTime);
        }
    }
}
