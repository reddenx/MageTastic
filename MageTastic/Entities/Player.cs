using MageTastic.Entities.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Entities
{
    class Player : Entity
    {
        public override EntityFrame CurrentStateFrame
        {
            get { throw new NotImplementedException(); }
        }

        public Player(Rectangle collisionBoxDimensions, Point boundingBoxDimensions, Vector2 origin, Texture2D texture, Vector2 position)
            //:base(collisionBoxDimensions, boundingBoxDimensions, origin, texture, position)
        { }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void HandleCollision(Entity colliders)
        {
            throw new NotImplementedException();
        }

        
    }
}
