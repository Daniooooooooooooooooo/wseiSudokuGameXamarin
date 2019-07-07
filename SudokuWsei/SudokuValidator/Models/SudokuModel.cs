using SudokuValidator.Exceptions;
using System.Linq;

namespace SudokuValidator.Models
{
    public class SudokuModel
    {
        #region Members
        private int[][] _tableInternal;
        private const string GENERAL_EXC_MSG = "Input string must contain exactly 81 digits (sudoku row by rowIndex)";
        #endregion Members

        #region Properties

        /// <summary>
        /// Gets the original sudoku input string.
        /// </summary>
        /// <value>
        /// The sudoku string.
        /// </value>
        public string SudokuString { get; }

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuModel"/> class.
        /// </summary>
        /// <param name="sudokuString">The sudoku input string.</param>
        public SudokuModel(string sudokuString = null)
        {
            InitTableInternal();

            if (sudokuString == null)
            {
                sudokuString = "000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            }

            //string exampleUnsolved =    "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            //string exampleSloved =      "534678912672195348198342567859761423426853791713924856961537284287419635345286179";
            //string exampleError =       "534678912672195348198342567859761423426853791713924856961537284287419635345286175";
            //string exampleWrongInput1 = "53467891267219534819834256785976142342685379171392485696153728428741963534528617";
            //string exampleWrongInput2 = "53467891267219534819834256785976142342685379171392485696153728428741963534528617x";
            //sudokuString = exampleSloved;

            SudokuString = sudokuString;
            ParseStringToTableInternal(sudokuString);
        }
        #endregion

        #region PublicMethods
        /// <summary>
        /// Gets the column.
        /// </summary>
        /// <param name="columnIndex">Index of the column.</param>
        /// <returns></returns>
        public int[] GetColumn(int columnIndex)
        {
            return _tableInternal.Select(x => x[columnIndex]).ToArray();
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns></returns>
        public int[] GetRow(int rowIndex)
        {
            return _tableInternal[rowIndex];
        }

        /// <summary>
        /// Gets the block.
        /// </summary>
        /// <param name="blockIndex">Index of the block.</param>
        /// <returns></returns>
        public int[] GetBlock(int blockIndex)
        {
            return GetBlock(blockIndex % 3, blockIndex / 3);
        }
        #endregion

        #region PrivateMethods
        /// <summary>
        /// Parses the string to table internal.
        /// </summary>
        /// <param name="sudokuString">The sudoku input string.</param>
        /// <exception cref="BadSudokuInputException">
        /// </exception>
        private void ParseStringToTableInternal(string sudokuString)
        {
            if (sudokuString?.Length != 81)
            {
                throw new BadSudokuInputException(GENERAL_EXC_MSG);
            }

            for (int i = 0; i < 9; i++)
            {
                string substr = sudokuString.Substring(i * 9, 9);
                for (int j = 0; j < 9; j++)
                {
                    bool parseSuccess = int.TryParse(substr[j].ToString(), out int digit);
                    if (!parseSuccess)
                    {
                        throw new BadSudokuInputException($"'{substr[j]}' is not a digit! {GENERAL_EXC_MSG}");
                    }

                    _tableInternal[i][j] = digit;
                }
            }
        }

        /// <summary>
        /// Initializes the table internal.
        /// </summary>
        private void InitTableInternal()
        {
            _tableInternal = new int[9][];
            for (int i = 0; i < 9; i++)
            {
                _tableInternal[i] = new int[9];
            }
        }

        /// <summary>
        /// Gets the block by x/y coordinates
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        private int[] GetBlock(int x, int y)
        {
            int[] values = new int[9];
            var startY = y * 3;
            var startX = x * 3;
            int index = 0;
            for (int i = startY; i < startY + 3; i++)
            {
                for (int j = startX; j < startX + 3; j++)
                {
                    values[index++] = _tableInternal[i][j];
                }
            }

            return values;
        }
        #endregion
    }
}