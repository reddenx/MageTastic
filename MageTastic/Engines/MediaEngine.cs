using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Engines
{
    class MediaEngine
    {
        private static MediaEngine Instance;

        private MediaEngine()
        { }

        public static void Instantiate()
        {
            if (Instance == null)
            {
                Instance = new MediaEngine();
            }
        }

        public static void PlaySound(object sound)
        { }

        public static void CrossfadeMusic(object music, object crossfadeTime)
        { }
    }
}
