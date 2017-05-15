using openTk.GameObjects.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openTk.GameObjects
{
    public sealed class GameObject
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
            //input processors
            Control?.Update(elapsedMilli);
            Physical?.Update(elapsedMilli);

            //output handlers
            Renderable?.Update(elapsedMilli);
            Audible?.Update(elapsedMilli);
        }
    }
}
