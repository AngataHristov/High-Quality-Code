
namespace Matrix
{
    using System;
    using RotatingWalkInMatrix;
    using RotatingWalkInMatrix.Interfaces;
    using RotatingWalkInMatrix.IO;

    public class MatrixMain
    {
        public static void Main()
        {
            IConsoleReaderWriter consoleReaderWriter = new ConsoleReaderWriter()
            {
                AutoFlush = true
            };

            MatrixCore matrixCore = new MatrixCore(consoleReaderWriter);

            consoleReaderWriter.Write("Enter a positive number: ");

            string input = consoleReaderWriter.ReadNextLine();
            int matrixSize = new int();
            bool isNumberCorrect = int.TryParse(input, out matrixSize);

            matrixSize = ValidateInput(isNumberCorrect, matrixSize, consoleReaderWriter);

            int[,] matrix = new int[matrixSize, matrixSize];
            int firstPositionInMatrix = 1;
            int row = 0;
            int col = 0;
            int horizontalDirection = 1;
            int verticalDirection = 1;

            matrixCore.SetupMatrix(matrix, row, col, firstPositionInMatrix, horizontalDirection, matrixSize, verticalDirection);

            matrixCore.PrintMatrix(matrix);
        }

        private static int ValidateInput(bool isNumberCorrect, int matrixSize, IConsoleReaderWriter consoleReaderWriter)
        {
            string input;
            while (!isNumberCorrect || matrixSize < 0 || matrixSize > 100)
            {
                consoleReaderWriter.Write("You haven't entered a correct positive number");
                input = consoleReaderWriter.ReadNextLine();
                isNumberCorrect = int.TryParse(input, out matrixSize);
            }
            return matrixSize;
        }
    }
}
