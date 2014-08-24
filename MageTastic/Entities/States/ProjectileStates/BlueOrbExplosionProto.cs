using MageTastic.Entities.Characters;
using MageTastic.Entities.Projectiles;
using MageTastic.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.ProjectileStates
{
    class BlueOrbExplosionProto : ProjectileStateBase
    {
        private ProjectileProtoBlueOrb Projectile { get { return (ProjectileProtoBlueOrb)Context; } }
        private TickTimer ExplosionTimer;
        private List<Character> CharactersAlreadyHit;

        public BlueOrbExplosionProto(ProjectileStateBase oldState)
            :base(oldState)
        {
            ExplosionTimer = new TickTimer(750);
            CharactersAlreadyHit = new List<Character>();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ExplosionTimer.Update(gameTime);
            if (ExplosionTimer.IsComplete)
            {
                Context.RemoveFromWorld = true;
            }
        }

        public override void HandleCollision(Entity collider)
        {
            if (!(collider is ProjectileBase) && collider != Projectile.Source.Owner)
            {
                if (collider is Character)
                {
                    var characterCollider = collider as Character;
                    if (characterCollider.Team != Projectile.Source.Owner.Team && !CharactersAlreadyHit.Contains(characterCollider))
                    {
                        foreach (var effect in Projectile.Source.Effects)
                        {
                            effect.ApplyTo(characterCollider);
                        }

                        CharactersAlreadyHit.Add(characterCollider);
                    }
                }
            }
            base.HandleCollision(collider);
        }

        public override EntityState CurrentState
        {
            get { return EntityState.Attacking; }
        }
    }
}
