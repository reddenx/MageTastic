using MageTastic.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Engines
{
    class GameStateEngine
    {
        private static GameStateEngine Instance;
        private GameObject GameRef;

        private GameStateEngine(GameObject gameRef) 
        {
            GameRef = gameRef;
        }

        public static void Initialize(GameObject gameRef)
        {
            Instance = Instance ?? new GameStateEngine(gameRef);
        }

        public static void StartGamePlay()
        {
            var gameplay = new GamePlay();
            Instance.GameRef.ChangeGameState(gameplay);
        }

        public static void MainMenu()
        {
        }
    }
}
