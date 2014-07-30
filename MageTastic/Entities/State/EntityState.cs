﻿using MageTastic.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Entities.State
{
    class EntityState
    {
        public EntityFrame CurrentFrame { get { return AnimationSet[CurrentState][(int)CurrentDirection][CurrentFrameIndex]; } }

        private readonly Dictionary<EntityStates, EntityFrame[][]> AnimationSet;
        private Direction CurrentDirection;
        private EntityStates CurrentState;
        private TickTimer CurrentFrameTimer;
        private int CurrentFrameIndex;

        public EntityState(Dictionary<EntityStates, EntityFrame[][]> animationSet)
        {
            AnimationSet = animationSet;
            CurrentState = EntityStates.Vitruvian;
            CurrentDirection = Direction.Up;
            CurrentFrameIndex = 0;
            CurrentFrameTimer = TickTimer.Expired;
        }



        //TODO uncouple this from proto player
        public void Update(GameTime gameTime, Direction facingDirection, EntityStates state)
        {
            CurrentDirection = facingDirection;
            CurrentState = state;

            CurrentFrameTimer.Update(gameTime);
            if (CurrentFrameTimer.IsComplete)
            {
                CurrentFrameIndex = (CurrentFrameIndex + 1) % AnimationSet[CurrentState][(int)CurrentDirection].Length; //looks goofy but it just doesn't let it go out of bounds
                CurrentFrameTimer = new TickTimer(CurrentFrame.FrameTime);
            }
        }
    }
}