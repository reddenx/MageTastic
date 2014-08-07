using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MageTastic.Entities.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MageTastic.Entities
{
    abstract class Character : Entity
    {
        public Character(Dictionary<EntityStates, EntityFrame[][]> animationSet, Texture2D texture, Vector2 position)
            : base(animationSet, texture, true, position)
        { }
    }
}
