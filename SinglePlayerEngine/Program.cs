using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SinglePlayerEngine
{
    static class Program
    {
        public static void Main()
        {
            using (var game = new GameContainer())
            {
                game.IsMouseVisible = true;
                game.Run();
            }
        }
    }
}
