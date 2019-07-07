using SudokuValidator.Interfaces;
using SudokuValidator.Models;
using System.Linq;

namespace SudokuValidator.ValidationRules
{
    class FilledRule : IValidationRule
    {
        /// <summary>
        /// Checks if the specified sudoku is fully filled
        /// </summary>
        /// <param name="sudoku">The sudoku to validate</param>
        /// <returns>Result of sudoku validation by filled rule</returns>
        public bool Check(SudokuModel sudoku)
        {
            return sudoku.SudokuString.All(c => c > '0' && c <= '9');
        }
    }
}
