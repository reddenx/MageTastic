using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Engines
{
    public enum MouseButtons
    {
        Left,
        Right,
        Middle,
        X1,
        X2
    }

    class InputEngine
    {
        private static InputEngine Instance;

        private KeyboardState PreviousKeyboardState;
        private KeyboardState CurrentKeyboardState;

        private MouseState PreviousMouseState;
        private MouseState CurrentMouseState;

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
            Instance.PreviousKeyboardState = Instance.CurrentKeyboardState;
            Instance.CurrentKeyboardState = Keyboard.GetState();

            Instance.PreviousMouseState = Instance.CurrentMouseState;
            Instance.CurrentMouseState = Mouse.GetState();
        }

        public static bool IsKeyDown(Keys key)
        {
            return Instance.CurrentKeyboardState.IsKeyDown(key);
        }

        public static bool IsKeyUp(Keys key)
        {
            return Instance.CurrentKeyboardState.IsKeyUp(key);
        }

        public static bool WasKeyPressed(Keys key)
        {
            return Instance.PreviousKeyboardState.IsKeyUp(key) && Instance.CurrentKeyboardState.IsKeyDown(key);
        }

        public static bool WasKeyReleased(Keys key)
        {
            return Instance.PreviousKeyboardState.IsKeyDown(key) && Instance.CurrentKeyboardState.IsKeyUp(key);
        }

        public static bool IsMouseButtonDown(MouseButtons button)
        {
            return GetMouseButtonStateFromButtons(button, Instance.CurrentMouseState) == ButtonState.Pressed;
        }

        public static bool IsMouseButtonUp(MouseButtons button)
        {
            return GetMouseButtonStateFromButtons(button, Instance.CurrentMouseState) == ButtonState.Released;
        }

        public static bool WasMouseButtonPressed(MouseButtons button)
        {
            return GetMouseButtonStateFromButtons(button, Instance.CurrentMouseState) == ButtonState.Pressed
                && GetMouseButtonStateFromButtons(button, Instance.PreviousMouseState) == ButtonState.Released;
        }

        public static bool WasMouseButtonReleased(MouseButtons button)
        {
            return GetMouseButtonStateFromButtons(button, Instance.CurrentMouseState) == ButtonState.Released
                && GetMouseButtonStateFromButtons(button, Instance.PreviousMouseState) == ButtonState.Pressed;
        }

        public static Point MousePositionInWindowsSpace()
        {
            return Instance.CurrentMouseState.Position;
        }

        private static ButtonState GetMouseButtonStateFromButtons(MouseButtons button, MouseState state)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    return state.LeftButton;
                case MouseButtons.Right:
                    return state.RightButton;
                case MouseButtons.Middle:
                    return state.MiddleButton;
                case MouseButtons.X1:
                    return state.XButton1;
                case MouseButtons.X2:
                    return state.XButton2;
            }

            throw new NotImplementedException();
        }
    }
}
