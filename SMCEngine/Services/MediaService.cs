using Microsoft.Xna.Framework;
using SMCEngine.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMCEngine.Services
{
    public class MediaService
    {
        public static void PlaySoundEffect(SoundEffects soundEffect)
        {
            //play sound, add to playing list etc.
            throw new NotImplementedException();
        }

        public static void PlayMusic(Songs song)
        {
            //cancel currently playing song and play this one
            //use locks
            throw new NotImplementedException();
        }

        public static void PlayMusic(Songs song, int crossfadeSeconds)
        {
            //play side by side with current song
            //use update to adjust volume over time
            throw new NotImplementedException();
        }

        public static void Update(GameTime gameTime)
        {
            //update crossfade volumes if necessary
            throw new NotImplementedException();
        }
    }
}
