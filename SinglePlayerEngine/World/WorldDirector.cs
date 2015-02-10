using Microsoft.Xna.Framework;
using SinglePlayerEngine.Entities;
using SinglePlayerEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePlayerEngine.World
{
    class WorldDirector
    {
        private Entity Player;

        public WorldDirector()
        { }

        public void PlacePlayerInWorld()
        {
            var player = new SinglePlayerEngine.Entities.Entity(ContentService.BlueMagicProjectileTexture, ContentService.BlueMagicProjectileAnimations);
            player.Brain = new SinglePlayerEngine.Entities.Brains.PlayerBrain(player);
            player.Physics = new SinglePlayerEngine.Entities.Physics.MovingPhysicalEntity(Vector2.Zero, Vector2.Zero, new Vector2(8), 600f, 200f);
            player.CurrentState = new SinglePlayerEngine.Entities.States.PlayerIdleState(player);
            WorldService.AddEntity(player);
        }

        public void Reset()
        { }
    }
}
