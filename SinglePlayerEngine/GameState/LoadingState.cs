using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SinglePlayerEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglePlayerEngine.GameState
{
    class LoadingState : GameStateBase
    {
        public LoadingState(GameContainer context)
            : base(context)
        { }

        public void StartupSynchronous(ContentManager content) { Startup(content); }
        protected override void Startup(ContentManager content)
        {

        }

        protected override void Shutdown(ContentManager content)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            RenderService.Clear(Color.Blue);
        }
    }
}
