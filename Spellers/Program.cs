using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new GameContainer())
            {
                game.IsMouseVisible = true;
                game.Run();
            }
        }
    }
}
