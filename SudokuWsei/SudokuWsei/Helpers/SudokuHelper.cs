using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuWsei.Helpers
{
    public class SudokuItem
    {
        public int Value { get; set; }
        public int Row { get; private set; }
        public int Column { get; private set; }

        public SudokuItem(int row, int column, int value = 0)
        {
            this.Value = value;
            this.Row = row;
            this.Column = column;
        }
    }
}
