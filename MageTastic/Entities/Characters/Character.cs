using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MageTastic.Entities.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MageTastic.Entities.Characters.Skills;
using MageTastic.Utility;

namespace MageTastic.Entities.Characters
{
    abstract class Character : Entity
    {
        public EntityTeam Team;
        public CharacterStats Stats;

        public CharacterAttachment LeftHand;

        public Character(Dictionary<EntityState, EntityFrame[][]> animationSet, Texture2D texture, Vector2 position, EntityTeam team, CharacterAttachment leftAttachment)
            : base(animationSet, texture, true, position)
        {
            Team = team;
            Stats = new CharacterStats(this, 10,0,0,0);
            LeftHand = leftAttachment;
        }

        public void UseSkill(SkillBase skill)
        {
            State.HandleAction(skill);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Assets.DevFont, Stats.Health.ToString(), Position, Color.Black);
        }

        abstract public void OnDeath();
    }
}
