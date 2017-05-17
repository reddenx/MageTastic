using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers.GameObjects.Components
{
    abstract class Component
    {
        public readonly Guid Id;

        protected readonly GameObject Parent;
        protected List<ComponentMessage> Messages;


        public Component(GameObject parent)
        {
            Id = Guid.NewGuid();
            Parent = parent;
        }

        public abstract void Update(uint elapsedMilli);

        public void Notify(ComponentMessage message)
        {
            Messages.Add(message);
        }
    }
}
