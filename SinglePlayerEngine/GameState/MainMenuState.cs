using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SinglePlayerEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SinglePlayerEngine.GameState
{
    class MainMenuState : GameStateBase
    {
        public MainMenuState(GameContainer context)
            :base(context)
        { }

        protected override void Startup(ContentManager content)
        {
            ContentService.LoadMainMenuContent();
        }

        protected override void Shutdown(ContentManager content)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            RenderService.Clear(Color.Red);
        }
    }
}
