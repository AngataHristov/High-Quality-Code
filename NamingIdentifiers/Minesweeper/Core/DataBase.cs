
namespace Minesweeper.Core
{
    using System.Collections.Generic;

    using Interfaces;

    public class DataBase : IDataBase
    {
        private readonly IList<IPlayer> allplayers;
        private readonly IList<IGameField> allfields;

        public DataBase()
        {
            this.allplayers = new List<IPlayer>();
            this.allfields = new List<IGameField>();
        }

        public IEnumerable<IPlayer> AllPlayers
        {
            get { return this.allplayers; }
        }

        public IEnumerable<IGameField> Allfields
        {
            get { return this.allfields; }
        }

        public void AddPlayer(IPlayer player)
        {
            this.allplayers.Add(player);
        }

        public void AddField(IGameField field)
        {
            this.allfields.Add(field);
        }
    }
}
