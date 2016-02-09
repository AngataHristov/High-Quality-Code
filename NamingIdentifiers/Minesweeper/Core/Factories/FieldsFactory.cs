
namespace Minesweeper.Core.Factories
{
    using Interfaces;
    using Models;

    public static class FieldsFactory
    {
        public static IGameField Create()
        {
            IGameField gameField = new GameField();

            for (int row = 0; row < gameField.Board.GetLength(0); row++)
            {
                for (int col = 0; col < gameField.Board.GetLength(1); col++)
                {
                    gameField.Board[row, col] = '?';
                }
            }

            return gameField;
        }
    }
}
