using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper2
{
    public class Board
    {
        private readonly int width;
        private readonly int height;
        private readonly int mines;
        public Cell[,] Cells { get; private set; }
        public Board(int width, int height, int mines)
        {
            this.width = width;
            this.height = height;
            this.mines = mines;
            Cells = new Cell[width, height];
            MakeStartBoard();
        }

        private void MakeStartBoard()
        {
            Random random = new Random();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Cells[i,j] = new Cell();
                }
            }

            int minesCount = 0;
            while (minesCount < mines)
            {
                int mineRow = random.Next(width);
                int mineCol = random.Next(height);
                if (!Cells[mineRow, mineCol].IsMine)
                {
                    Cells[mineRow, mineCol].IsMine = true;
                    minesCount++;
                }
            }
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (!Cells[i, j].IsMine)
                    {
                        Cells[i, j].AdjacentMines = CountAdjacentMines(i, j);
                    }
                }
            }
        }

        private int CountAdjacentMines(int row, int col)
        {
            int theCount = 0;
            int[] rowOffset = {-1,-1,-1,0,0,1,1,1};
            int[] colOffset = {-1,0,1,-1,1,-1,0,1};
            for (int i = 0; i < rowOffset.Length; i++)
            {
                int newRow = row + rowOffset[i];
                int newCol = col + colOffset[i];
                if (IsInsideBoard(newRow, newCol) && Cells[newRow, newCol].IsMine)
                {
                    theCount++;
                }
            }
            return theCount;
        }

        private bool IsInsideBoard(int row, int col)
        {
            return (row >= 0 && col >= 0 && row < width && col < height);
        }

        public void openCells(int row, int col)
        {
            if (!IsInsideBoard(row, col) || Cells[row,col].IsOpened )
            {
                return;
            }

            Cells[row, col].IsOpened = true;
            if (Cells[row, col].AdjacentMines == 0)
            {
                int[] rowOffset = { -1, -1, -1, 0, 0, 1, 1, 1 };
                int[] colOffset = { -1, 0, 1, -1, 1, -1, 0, 1 };
                for (int i = 0; i < rowOffset.Length; i++)
                {
                    int newRow = row + rowOffset[i];
                    int newCol = col + colOffset[i];
                    openCells(newRow, newCol);
                }
            }
        }

        public bool HasWon()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (!Cells[i, j].IsMine && !Cells[i, j].IsOpened)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void ShowBoard(bool openAll)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (openAll)
                    {
                        Cells[i, j].IsOpened = true;
                    }

                    Console.Write(Cells[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
