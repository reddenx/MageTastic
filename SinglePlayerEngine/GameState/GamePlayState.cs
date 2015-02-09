using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using SinglePlayerEngine.Services;

namespace SinglePlayerEngine.GameState
{
    class GamePlayState : GameStateBase
    {
        public GamePlayState(GameStateBase previousState)
            : base(previousState)
        { }

        protected override void Startup(ContentManager content)
        {
            Thread.Sleep(1500);
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
