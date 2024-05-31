using System;

namespace Minesweeper2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = 20;
            int height = 10;
            int mines = 20;
            Game game = new Game(height, width,mines);
            game.Play();
        }

    }
}
