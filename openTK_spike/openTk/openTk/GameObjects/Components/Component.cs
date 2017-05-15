using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openTk.GameObjects.Components
{
    public abstract class Component
    {
        public readonly Guid Id;

        private List<ComponentMessage> Messages;
        protected GameObject Parent;

        public Component Renderable;
        public Component Control;
        public Component Physical;
        public Component Audible;

        public Component(GameObject parent)
        {
            Id = Guid.NewGuid();
            Parent = parent;
        }

        public virtual void Initialize() { }

        public virtual void Update(uint elapsedMilli)
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
