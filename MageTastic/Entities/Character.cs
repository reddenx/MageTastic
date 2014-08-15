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
        public EntityTeam Team;
        public CharacterStats Stats;

        public Character(Dictionary<EntityState, EntityFrame[][]> animationSet, Texture2D texture, Vector2 position, EntityTeam team)
            : base(animationSet, texture, true, position)
        {
            Team = team;
            Stats = new CharacterStats();
        }

        public void UseSkill(SkillProto skill)
        {
            State.HandleAction(skill);
        }
    }
}
