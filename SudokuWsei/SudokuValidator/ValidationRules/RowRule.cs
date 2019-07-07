using SudokuValidator.Interfaces;
using SudokuValidator.Models;
using System.Collections.Generic;
using System.Linq;

namespace SudokuValidator.ValidationRules
{
    public class RowRule : IValidationRule
    {
        /// <summary>
        /// Checks the specified sudoku only by rows rule.
        /// </summary>
        /// <param name="sudoku">The sudoku to validate</param>
        /// <returns>Result of rows validation</returns>
        public bool Check(SudokuModel sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                HashSet<int> diffChecker = new HashSet<int>();
                if (!sudoku.GetRow(i).All(x => diffChecker.Add(x)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
