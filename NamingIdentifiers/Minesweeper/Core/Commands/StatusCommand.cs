
namespace Minesweeper.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Interfaces;

    public class StatusCommand : CommandAbstract
    {
        public StatusCommand(IEngine engine)
            : base(engine)
        {

        }

        public override void Execute()
        {
            ShowScores(this.Engine.DB.AllPlayers);
        }

        private void ShowScores(IEnumerable<IPlayer> players)
        {
            base.Engine.Writer.WriteLine("\nScores:");

            if (players.Any())
            {
                int counter = new int();

                foreach (IPlayer player in players)
                {
                    counter++;

                    base.Engine.Writer.WriteLine(string.Format("{0}. {1} --> {2} success steps, before bomb exploded", counter, player.Name, player.Scores));
                }

                base.Engine.Writer.WriteLine(string.Empty);
            }
            else
            {
                base.Engine.Writer.WriteLine("Empty scorelist!\n");
            }
        }
    }
}
