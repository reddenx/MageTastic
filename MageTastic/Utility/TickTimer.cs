using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic.Utility
{
    class TickTimer
    {
        private readonly int StartMilli;

        public TimeSpan CurrentCountdown { get; private set; }
        
        public bool IsComplete
        {
            get { return CurrentCountdown <= TimeSpan.Zero;}
        }
        
        public float Completion
        {
            get { return (float)(CurrentCountdown.TotalMilliseconds / StartMilli); }
        }

        public TickTimer(int milli)
        {
            StartMilli = milli;
            CurrentCountdown = TimeSpan.FromMilliseconds(milli);
        }

        public void Update(GameTime gameTime)
        {
            CurrentCountdown -= gameTime.ElapsedGameTime;
        }

        public static TickTimer Expired { get { return new TickTimer(0); } }
    }
}
