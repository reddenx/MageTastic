using Spellers.GameObjects.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.GameObjects
{
    class GameObject
    {
        public readonly Guid Id;

        public Component Renderable;
        public Component Control;
        public Component Physical;
        public Component Audible;

        public GameObject()
        {
            Id = Guid.NewGuid();
        }

        public void Update(uint elapsedMilli)
        {
            //handle input
            Control?.Update(elapsedMilli);

            //determine output
            Physical?.Update(elapsedMilli);
            Renderable?.Update(elapsedMilli);
            Audible?.Update(elapsedMilli);
        }
    }
}
