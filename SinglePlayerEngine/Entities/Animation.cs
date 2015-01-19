using Microsoft.Xna.Framework;
using SinglePlayerEngine.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglePlayerEngine.Entities
{
    class Animation
    {
        private EntityAnimationFrame[] AnimationFrames;
        private int CurrentFrameIndex;
        private TickTimer FrameTimer;

        public Animation(EntityAnimationFrame[] animation)
        {
            AnimationFrames = animation;
            FrameTimer = TickTimer.Expired;

            Reset();
        }

        public void Reset()
        {
            CurrentFrameIndex = 0;
            FrameTimer.Reset(AnimationFrames[CurrentFrameIndex].FrameTime);
        }

        public EntityAnimationFrame GetCurrentFrame()
        {
            return AnimationFrames[CurrentFrameIndex];
        }
    }
}
