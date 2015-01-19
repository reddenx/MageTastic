using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePlayerEngine.Services
{
    class InputService
    {
        private static InputService Instance;

        private KeyboardState PreviousState;
        private KeyboardState CurrentState;

        public static void Initialize()
        {
            Instance = new InputService();
        }

        public InputService()
        {
            CurrentState = Keyboard.GetState();
            PreviousState = Keyboard.GetState();
        }

        public static void Update(GameTime gameTime)
        {
            Instance.PreviousState = Instance.CurrentState;
            Instance.CurrentState = Keyboard.GetState();
        }

        /// <summary>
        /// Use Key Mapping -> ActionDefinitions
        /// </summary>
        public static bool WasKeyPressed(Keys key)
        {
            return !Instance.PreviousState.IsKeyDown(key)
                && Instance.CurrentState.IsKeyDown(key);
        }

        /// <summary>
        /// Use Key Mapping -> ActionDefinitions
        /// </summary>
        public static bool IsKeyHeld(Keys key)
        {
            return Instance.CurrentState.IsKeyDown(key);
        }

        /// <summary>
        /// Use Key Mapping -> ActionDefinitions
        /// </summary>
        public static bool WasKeyRelease(Keys key)
        {
            return Instance.PreviousState.IsKeyDown(key)
                && !Instance.CurrentState.IsKeyDown(key);
        }
    }

    static class ActionDefinitions
    {
        public static Keys Player1MoveLeft = Keys.A;
        public static Keys Player1MoveRight = Keys.D;
        public static Keys Player1MoveUp = Keys.W;
        public static Keys Player1MoveDown = Keys.S;
    }
}
