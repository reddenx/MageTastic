using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.GameStates
{
    class LoadingGameState : GameStateBase
    {
        public LoadingGameState(Action<GameStateBase> changeGamestate) : base(changeGamestate)
        {
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Reactivate()
        {
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
