using MageTastic.Entities.Characters;
using MageTastic.Entities.Projectiles;
using MageTastic.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Entities.States.ProjectileStates
{
    //TODO this is a proto, make into generic projectile
    class BlueOrbFlyingProto : ProjectileStateBase
    {
        private ProjectileProtoBlueOrb Projectile { get { return (ProjectileProtoBlueOrb)Context; } }

        private TickTimer ExplosionTimer;

        public BlueOrbFlyingProto(ProjectileProtoBlueOrb context, int flyLife)
            : base(context)
        {
            ExplosionTimer = new TickTimer(flyLife);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            Projectile.Position += Projectile.Velocity;

            ExplosionTimer.Update(gameTime);
            if (ExplosionTimer.IsComplete)
            {
                Explode();
            }
        }

        private void Explode()
        {
            ChangeState(new BlueOrbExplosionProto(this));
        }

        public override EntityState CurrentState
        {
            get { return EntityState.Idle; }
        }

        public override void HandleCollision(Entity collider)
        {
            if(!(collider is ProjectileBase) && collider != Projectile.Source.Owner)
            {
                if (collider is Character)
                {
                    var characterCollider = collider as Character;
                    if (characterCollider.Team != Projectile.Source.Owner.Team)
                    {
                        foreach (var effect in Projectile.Source.Effects)
                        {
                            effect.ApplyTo(characterCollider);
                        }
                        Explode();
                    }
                }
            }
        }
    }
}
