
namespace Minesweeper.Interfaces
{
    public interface IGameField
    {
        int FielfdRows { get; }

        int FielfdColumns { get; }

        char[,] Board { get; }
    }
}
