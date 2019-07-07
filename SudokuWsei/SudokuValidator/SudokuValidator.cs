using SudokuValidator.Interfaces;
using SudokuValidator.Models;
using SudokuValidator.ValidationRules;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SudokuValidator
{
    public static class SudokuValidator
    {
        /// <summary>
        /// Validates the specified sudoku.
        /// </summary>
        /// <param name="sudoku">The sudoku to validate.</param>
        /// <returns>Result of sudoku validation</returns>
        public static bool Validate(SudokuModel sudoku)
        {
            IEnumerable<IValidationRule> validationRules = new List<IValidationRule>
            {
                new FilledRule(),
                new RowRule(),
                new ColumnRule(),
                new BlockRule()
            };

            return validationRules.All(rule => rule.Check(sudoku));
        }
    }
}
