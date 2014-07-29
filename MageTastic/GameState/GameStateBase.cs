using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.GameState
{
    abstract class GameStateBase
    {
        protected GameStateBase()
        {
        }

        abstract public void Initialize();
        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch);
    }
}
