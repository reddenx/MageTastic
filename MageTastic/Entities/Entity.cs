using MageTastic.Entities.State;
using MageTastic.Entities.State.CharacterState;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Entities
{
    abstract class Entity
    {
        //data
        public Vector2 Position;
        public bool IsCollidable;
        public readonly Texture2D Texture;
        public readonly Dictionary<EntityStates, EntityFrame[][]> AnimationSet;
        public bool RemoveFromWorld;
        
        //logic
        public AnimatedStateBase State;

        public Entity(Dictionary<EntityStates, EntityFrame[][]> animationSet,
            Texture2D texture,
            bool isCollidable,
            Vector2 position)
        {
            AnimationSet = animationSet;
            Texture = texture;
            IsCollidable = isCollidable;
            Position = position;
        }

        

        //methods
        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);
        abstract public void HandleCollision(Entity colliders);

    }
}
