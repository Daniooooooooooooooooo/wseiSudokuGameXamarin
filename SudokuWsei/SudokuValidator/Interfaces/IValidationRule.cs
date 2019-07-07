using SudokuValidator.Models;

namespace SudokuValidator.Interfaces
{
    interface IValidationRule
    {
        /// <summary>
        /// Checks the specified sudoku.
        /// </summary>
        /// <param name="sudoku">The sudoku to check</param>
        /// <returns></returns>
        bool Check(SudokuModel sudoku);
    }
}
