using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace openTk
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new GameContainer())
            {
                game.Run(60);
            }
        }


        private static void ChangeResolution()
        {
            var device = DisplayDevice.GetDisplay(DisplayIndex.Default);
            device.ChangeResolution(800, 600, -1, -1);
        }


        private static void PrintDevices()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            foreach (DisplayDevice device in DisplayDevice.AvailableDisplays)
#pragma warning restore CS0618 // Type or member is obsolete
            {
                Console.WriteLine($"primary: {device.IsPrimary}, bounds: {device.Bounds}, bits/pix: {device.BitsPerPixel}");
            }
        }

        
    }
}
