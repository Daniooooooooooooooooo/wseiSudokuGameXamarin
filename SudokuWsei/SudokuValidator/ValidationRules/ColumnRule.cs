using SudokuValidator.Interfaces;
using SudokuValidator.Models;
using System.Collections.Generic;
using System.Linq;

namespace SudokuValidator.ValidationRules
{
    class ColumnRule : IValidationRule
    {
        /// <summary>
        /// Checks the specified sudoku only by columns rule.
        /// </summary>
        /// <param name="sudoku">The sudoku to validate</param>
        /// <returns>Result of columns validation</returns>
        public bool Check(SudokuModel sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                HashSet<int> diffChecker = new HashSet<int>();
                if (!sudoku.GetColumn(i).All(x => diffChecker.Add(x)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
