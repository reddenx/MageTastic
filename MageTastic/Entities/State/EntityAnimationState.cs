﻿using MageTastic.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Entities.State
{
    class EntityAnimationState
    {
        public EntityFrame CurrentFrame { get { return AnimationSet[CurrentState][CurrentFrameIndex]; } }

        private readonly Dictionary<EntityState, EntityFrame[]> AnimationSet;
        private EntityState CurrentState;
        private TickTimer CurrentFrameTimer;
        private int CurrentFrameIndex;

        public EntityAnimationState(Dictionary<EntityState, EntityFrame[]> animationSet)
        {
            AnimationSet = animationSet;
            CurrentState = EntityState.Vitruvian;
            CurrentFrameIndex = 0;
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrameTimer.Update(gameTime);
            if (CurrentFrameTimer.IsComplete)
            {
                CurrentFrameIndex = (CurrentFrameIndex + 1) % AnimationSet[CurrentState].Length; //looks goofy but it just doesn't let it go out of bounds
                CurrentFrameTimer = new TickTimer(CurrentFrame.FrameTime);
            }
        }
    }
}