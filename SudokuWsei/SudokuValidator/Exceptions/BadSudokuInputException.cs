using System;

namespace SudokuValidator.Exceptions
{
    public class BadSudokuInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadSudokuInputException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BadSudokuInputException(string message) : base(message)
        {
            
        }
    }
}
