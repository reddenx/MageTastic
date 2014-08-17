using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.Characters
{
    class CharacterAttachment
    {
        public readonly Texture2D Texture;
        public readonly Dictionary<EntityState, EntityFrame[][]> AnimationSet;

        public CharacterAttachment(Dictionary<EntityState, EntityFrame[][]> animationSet, Texture2D texture)
        {
            AnimationSet = animationSet;
            Texture = texture;
        }
    }
}
