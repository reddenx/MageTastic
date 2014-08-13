using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Entities.State
{
    class EntityFrame
    {
        public readonly Point BoundingBoxDimensions;
        public readonly Rectangle PhysicsBox;
        public readonly Vector2 Origin;
        public readonly Vector2 RightAttach;
        public readonly Vector2 LeftAttach;
        public readonly Rectangle[] DamageZones;
        public readonly EntityFrame RightAttachment;
        public readonly EntityFrame LeftAttachment;
        public readonly Rectangle SpriteSheetSourceRectangle;
        public readonly int FrameTime;
        public readonly float Scale;

        public EntityFrame(
            Point bounds, 
            Rectangle physics, 
            Vector2 origin,
            Vector2 rightAttach, 
            Vector2 leftAttach, 
            Rectangle[] damageZones,
            EntityFrame rightAttachment,
            EntityFrame leftAttachment,
            Rectangle spriteSheetSourceRectangle,
            int frameTime)
        {
            BoundingBoxDimensions = bounds;
            PhysicsBox = physics;
            Origin = origin;
            RightAttach = rightAttach;
            LeftAttach = leftAttach;
            DamageZones = damageZones;
            RightAttachment = rightAttachment;
            LeftAttachment = leftAttachment;
            FrameTime = frameTime;
            SpriteSheetSourceRectangle = spriteSheetSourceRectangle;

            Scale = (float)BoundingBoxDimensions.X / (float)SpriteSheetSourceRectangle.Width;
        }

    }
}
