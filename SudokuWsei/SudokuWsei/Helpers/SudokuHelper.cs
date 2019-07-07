using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuWsei.Helpers
{
    public class SudokuItem
    {
        public int Value { get; set; }

        public SudokuItem(int value = 0)
        {
            this.Value = value;
        }
    }
}
