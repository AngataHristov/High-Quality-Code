
namespace Minesweeper.Core.Factories
{
    using Interfaces;
    using Models;

    public static class PlayersFactory
    {
        public static IPlayer Create(string name, int scores)
        {
            return new Player(name, scores);
        }
    }
}
