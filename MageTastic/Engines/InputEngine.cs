using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Engines
{
    class InputEngine
    {
        private static InputEngine Instance;

        private KeyboardState PreviousState;
        private KeyboardState CurrentState;

        private InputEngine() { }

        public static void Instantiate()
        {
            if (Instance == null)
            {
                Instance = new InputEngine();
            }
        }

        public static void Update(GameTime gameTime)
        {
            Instance.PreviousState = Instance.CurrentState;
            Instance.CurrentState = Keyboard.GetState();
        }

        public static bool IsKeyDown(Keys key)
        {
            return Instance.CurrentState.IsKeyDown(key);
        }

        public static bool IsKeyUp(Keys key)
        {
            return Instance.CurrentState.IsKeyUp(key);
        }

        public static bool WasKeyPressed(Keys key)
        {
            return Instance.PreviousState.IsKeyUp(key) && Instance.CurrentState.IsKeyDown(key);
        }

        public static bool WasKeyReleased(Keys key)
        {
            return Instance.PreviousState.IsKeyDown(key) && Instance.CurrentState.IsKeyUp(key);
        }
    }
}
