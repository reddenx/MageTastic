using MageTastic.Engines;
using MageTastic.Entities.Characters;
using MageTastic.Entities.Characters.Skills;
using MageTastic.Entities.States;
using MageTastic.Entities.States.ProjectileStates;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.Projectiles
{
    class ProjectileProtoBlueOrb : ProjectileBase
    {
        public ProjectileProtoBlueOrb(Dictionary<EntityState, EntityFrame[][]> animationSet, Texture2D texture, Vector2 position, Vector2 velocity, int flyTime, SkillBase source)
            : base(animationSet, texture, true, position, velocity, source)
        {
            State = new BlueOrbFlyingProto(this, flyTime);
        }
    }
}
