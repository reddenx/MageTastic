using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
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
            ContentService.LoadGameplayContent(content);
            WorldService.StartupWorld();
        }

        protected override void Shutdown(ContentManager content)
        {
        }

        public override void Update(GameTime gameTime)
        {
            WorldService.Update(gameTime);
            UIService.Update(gameTime);

            if (InputService.IsKeyHeld(Keys.Escape))
            {
                base.Exit();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            RenderService.Clear(Color.Red);

            RenderService.DrawWorld();
        }
    }
}
