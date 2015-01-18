using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SinglePlayerEngine.Entities.Brains
{
    abstract class BrainComponent
    {
        protected readonly Entity Context;

        public BrainComponent(Entity context)
        {
            Context = context;
        }

        public abstract void Update(GameTime gameTime);
    }
}
