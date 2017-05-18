using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Spellers.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.GameServices
{
    class InputService
    {
        private static InputService Instance;
        private List<KeyActionState> ActionBindings;
        private Dictionary<InputActions, List<InputActionDelegate>> Subscriptions;

        public static void Initialize(Dictionary<Keys, InputActions> actionBindings)
        {
            Instance = new InputService();
            Instance.Subscriptions = new Dictionary<InputActions, List<InputActionDelegate>>();

            Instance.ActionBindings = actionBindings.Select(binding => new KeyActionState()
            {
                Key = binding.Key,
                Action = binding.Value,
                Pressed = false,
            }).ToList();
        }

        public static void Update(GameTime gameTIme)
        {
            var currentState = Keyboard.GetState();

            foreach (var binding in Instance.ActionBindings)
            {
                if (currentState.IsKeyDown(binding.Key))
                {
                    if (binding.Pressed)
                    {
                        Instance.NotifyAction(binding.Action, ButtonStepState.Held);
                    }
                    else
                    {
                        Instance.NotifyAction(binding.Action, ButtonStepState.Pressed);
                        binding.Pressed = true;
                    }
                }
                else if (binding.Pressed && currentState.IsKeyUp(binding.Key))
                {
                    Instance.NotifyAction(binding.Action, ButtonStepState.Released);
                    binding.Pressed = false;
                }
            }
        }

        private void NotifyAction(InputActions action, ButtonStepState state)
        {
            if (Subscriptions.ContainsKey(action))
            {
                foreach (var handler in Subscriptions[action])
                {
                    handler(action, state);
                }
            }
        }

        public static void SubscribeToInput(InputActions action, InputActionDelegate handler)
        {
            if (Instance.Subscriptions.ContainsKey(action))
            {
                Instance.Subscriptions[action].Add(handler);
            }
            else
            {
                Instance.Subscriptions[action] = new List<InputActionDelegate>() { handler };
            }
        }
    }

    delegate void InputActionDelegate(InputActions actionName, ButtonStepState buttonState);

    enum ButtonStepState
    {
        Held,
        Pressed,
        Released
    }

    class KeyActionState
    {
        public Keys Key;
        public bool Pressed;
        public InputActions Action;
    }

    enum InputActions
    { }
}
