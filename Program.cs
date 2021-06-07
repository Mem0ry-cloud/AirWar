using System;
using AIRWAR;
//made by Mem0ry
namespace _15._02._21
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
