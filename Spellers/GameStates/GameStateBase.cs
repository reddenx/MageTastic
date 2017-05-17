using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.GameStates
{
    abstract class GameStateBase : IDisposable
    {
        private readonly Action<GameStateBase> ChangeParentGameState;

        protected GameStateBase(GameStateBase previousState)
        {
            this.ChangeParentGameState = previousState.ChangeParentGameState;
        }

        protected GameStateBase(Action<GameStateBase> changeGamestate)
        {
            ChangeParentGameState = changeGamestate;
        }

        protected void ChangeGameState(GameStateBase newGameState)
        {
            ChangeGameState(newGameState);
        }

        public abstract void Startup();
        public abstract void Shutdown();
        public abstract void Dispose();
    }
}
