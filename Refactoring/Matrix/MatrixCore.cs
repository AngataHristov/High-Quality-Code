
namespace RotatingWalkInMatrix
{
    using System;
    using Interfaces;

    /// <summary>
    /// Holds all the logic about operations in matrix
    /// </summary>
    public class MatrixCore
    {
        // По този начин се разкачам от статичните методи и така те стават тестваеми! 

        private const int NumberOfPossibleDirections = 8;

        public MatrixCore(IConsoleReaderWriter consoleReaderWriter)
        {
            this.ConsoleReaderWriter = consoleReaderWriter;
        }

        public IConsoleReaderWriter ConsoleReaderWriter { get; private set; }

        public void SetupMatrix(int[,] matrix, int row, int col, int matrixSquare,
            int horizontalDirection, int matrixSize, int verticalDirection)
        {
            while (true)
            {
                matrix[row, col] = matrixSquare;

                if (!this.CheckNextCell(matrix, row, col))
                {
                    break;
                }

                while (row + horizontalDirection >= matrixSize ||
                       row + horizontalDirection < 0 ||
                       col + verticalDirection >= matrixSize ||
                       col + verticalDirection < 0 ||
                       matrix[row + horizontalDirection, col + verticalDirection] != 0)
                {
                    this.ChangeDirection(ref horizontalDirection, ref verticalDirection);
                }

                row += horizontalDirection;
                col += verticalDirection;
                matrixSquare++;
            }
        }

        private void ChangeDirection(ref int horizontalDirection, ref int verticalDirection)
        {
            int[] horizontalDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] verticalDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int currentPosition = 0;
            for (int count = 0; count < NumberOfPossibleDirections; count++)
            {
                if (horizontalDirections[count] == horizontalDirection && verticalDirections[count] == verticalDirection)
                {
                    currentPosition = count;
                    break;
                }
            }

            if (currentPosition == NumberOfPossibleDirections - 1)
            {
                horizontalDirection = horizontalDirections[0];
                verticalDirection = verticalDirections[0];
                return;
            }

            horizontalDirection = horizontalDirections[currentPosition + 1];
            verticalDirection = verticalDirections[currentPosition + 1];
        }

        private bool CheckNextCell(int[,] arr, int x, int y)
        {
            int[] horizontalDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] verticalDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < NumberOfPossibleDirections; i++)
            {
                if (x + horizontalDirections[i] >= arr.GetLength(0) || x + horizontalDirections[i] < 0)
                {
                    horizontalDirections[i] = 0;
                }

                if (y + verticalDirections[i] >= arr.GetLength(0) || y + verticalDirections[i] < 0)
                {
                    verticalDirections[i] = 0;
                }
            }

            for (int i = 0; i < NumberOfPossibleDirections; i++)
            {
                if (arr[x + horizontalDirections[i], y + verticalDirections[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    this.ConsoleReaderWriter.Write(string.Format("{0,3}", matrix[row, col]));
                }

                this.ConsoleReaderWriter.Write(string.Empty);
            }
        }
    }
}
