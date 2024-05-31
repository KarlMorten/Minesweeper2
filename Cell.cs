using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper2
{
    public class Cell
    {
        public bool IsMine { get; set; }
        public bool IsOpened { get; set; }
        public int AdjacentMines { get; set; }

        public Cell()
        {
            IsMine = false;
            IsOpened = false;
            AdjacentMines = 0;
        }

        public override string ToString()
        {
            if (!IsOpened) return "?";
            if (IsMine) return "*";
            if (AdjacentMines > 0) return AdjacentMines.ToString();
            return " ";
        }
    }
}
