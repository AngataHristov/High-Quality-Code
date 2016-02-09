
namespace Minesweeper.Models
{
    using Interfaces;

    public class GameField : IGameField
    {
        private const int FielfdRowsDefault = 5;
        private const int FieldColumnsDefault = 10;

        public GameField()
        {
            this.FielfdRows = FielfdRowsDefault;
            this.FielfdColumns = FieldColumnsDefault;
            this.Board = new char[FielfdRowsDefault, FieldColumnsDefault];
        }

        public int FielfdRows { get; private set; }

        public int FielfdColumns { get; private set; }

        public char[,] Board { get; }
    }
}
