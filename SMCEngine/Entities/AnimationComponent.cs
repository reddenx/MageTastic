﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SMCEngine.Entities
{
    public class AnimationComponent
    {
        public Texture2D Texture;
        public Dictionary<EntityActions, Dictionary<EntityDirections, EntityFrame[]>> AnimationDefinitions;
    }
}
