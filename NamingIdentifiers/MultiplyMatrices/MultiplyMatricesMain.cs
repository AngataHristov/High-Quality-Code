
namespace ConsoleApplication1
{
    using System;

    public class MultiplyMatricesMain
    {
        public static void Main()
        {
            double[,] firstMatrix = new double[,]
            {
                { 1, 3 },
                { 5, 7 }
            };

            double[,] secondMatrix = new double[,]
            {
                { 4, 2 },
                { 1, 5 }
            };

            double[,] result = MultiplyMatrix(firstMatrix, secondMatrix);

            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    Console.Write(result[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static double[,] MultiplyMatrix(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new InvalidOperationException("The columns of the first matrix must be equal to the rows of the second matrix!");
            }

            int firstMatrixLenght = firstMatrix.GetLength(1);

            double[,] result = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    for (int position = 0; position < firstMatrixLenght; position++)
                    {
                        result[row, col] += firstMatrix[row, position] * secondMatrix[position, col];
                    }
                }
            }

            return result;
        }
    }
}