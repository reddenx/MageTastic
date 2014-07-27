using MageTastic.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTastic
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameObject())
            {
                game.IsMouseVisible = true;
                game.Run();
            }
        }
    }
}
