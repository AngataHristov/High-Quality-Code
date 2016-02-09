
namespace Minesweeper.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Factories;
    using Interfaces;

    public class RestartCommand : CommandAbstract
    {
        public RestartCommand(IEngine engine)
            : base(engine)
        {

        }

        public override void Execute()
        {
            IGameField gameField = FieldsFactory.Create();


            MakeBorders(gameField);
        }

        private char[,] InsertMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    gameField[row, col] = '-';
                }
            }

            List<int> listOfNumbers = new List<int>();
            while (listOfNumbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!listOfNumbers.Contains(randomNumber))
                {
                    listOfNumbers.Add(randomNumber);
                }
            }

            foreach (int number in listOfNumbers)
            {
                int column = number / cols;
                int row = number % cols;

                if (row == 0 && number != 0)
                {
                    column--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                gameField[column, row - 1] = '*';
            }

            return gameField;
        }

        private void MakeBorders(IGameField gameField)
        {
            int rows = gameField.Board.GetLength(0);
            int columns = gameField.Board.GetLength(1);

            base.Engine.Writer.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            base.Engine.Writer.WriteLine("   ---------------------");

            for (int row = 0; row < rows; row++)
            {
                base.Engine.Writer.Write(string.Format("{0} | ", row));

                for (int col = 0; col < columns; col++)
                {
                    base.Engine.Writer.Write(string.Format("{0} ", gameField.Board[row, col]));
                }

                base.Engine.Writer.Write("|");

                Console.WriteLine();
            }

            base.Engine.Writer.WriteLine("   ---------------------\n");
        }
    }
}
