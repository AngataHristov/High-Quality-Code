
namespace Minesweeper.Interfaces
{
    using System.Collections.Generic;

    public interface IDataBase
    {
        IEnumerable<IPlayer> AllPlayers { get; }

        IEnumerable<IGameField> Allfields { get; }

        void AddPlayer(IPlayer player);

        void AddField(IGameField field);
    }
}
