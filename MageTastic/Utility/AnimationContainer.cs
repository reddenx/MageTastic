using MageTastic.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Utility
{
    class AnimationContainer
    {
        private readonly EntityFrame[][] Animation;

        public EntityFrame CurrentFrame;

        private int FrameIndex;
        private TickTimer FrameTimer;

        public AnimationContainer(EntityFrame[][] animation)
        {
            Animation = animation;
            FrameIndex = 0;
            CurrentFrame = animation[0][0];
            FrameTimer = new TickTimer(CurrentFrame.FrameTime);
        }

        public void Update(GameTime gameTime, Direction currentDirection)
        {
            FrameTimer.Update(gameTime);
            if (FrameTimer.IsComplete)
            {
                FrameIndex = (FrameIndex + 1) % Animation[(int)currentDirection].Length; //looks goofy but it just doesn't let it go out of bounds
                CurrentFrame = Animation[(int)currentDirection][FrameIndex];
                FrameTimer = new TickTimer(CurrentFrame.FrameTime);
            }
        }
    }
}
