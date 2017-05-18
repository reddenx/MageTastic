using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.GameStates
{
    class MainMenuGameState : GameStateBase
    {
        public MainMenuGameState(Action<GameStateBase> changeGamestate) : base(changeGamestate)
        {
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Shutdown()
        {
            throw new NotImplementedException();
        }

        public override void Startup()
        {
            throw new NotImplementedException();
        }
    }
}
