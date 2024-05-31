using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper2
{
    public class Game
    {
        private readonly Board board;
        private bool gameOver;

        public Game(int width, int height, int mines)
        {
            board = new Board(width, height,mines);
            gameOver = false;
        }

        public void Play()
        {
            while (!gameOver)
            {
                board.ShowBoard(false);
                Console.WriteLine("Skriv rad og kolonne du vil opne med mellomrom (for eksempel 5 6)");
                string answer = Console.ReadLine();
                string[] parts = answer.Split(' ');
                int row = Convert.ToInt32(parts[0])-1;
                int col = Convert.ToInt32(parts[1])-1;

                if (board.Cells[row, col].IsMine)
                {
                    gameOver = true;
                    Console.WriteLine("Du traff ei mine. Betre lykke neste gong.");
                }
                else
                {
                    board.openCells(row, col);
                    if (board.HasWon())
                    {
                        gameOver = true;
                        Console.WriteLine("Gratulerer. Du vann.");
                    }
                }
            }

            board.ShowBoard(true);
        }
    }
}
