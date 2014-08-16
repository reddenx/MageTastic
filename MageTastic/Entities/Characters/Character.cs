using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MageTastic.Entities.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MageTastic.Entities.Characters.Skills;

namespace MageTastic.Entities.Characters
{
    abstract class Character : Entity
    {
        public EntityTeam Team;
        public CharacterStats Stats;

        public Character(Dictionary<EntityState, EntityFrame[][]> animationSet, Texture2D texture, Vector2 position, EntityTeam team)
            : base(animationSet, texture, true, position)
        {
            Team = team;
            Stats = new CharacterStats(this);
        }

        public void UseSkill(SkillProto skill)
        {
            State.HandleAction(skill);
        }

        abstract public void OnDeath();
    }
}
