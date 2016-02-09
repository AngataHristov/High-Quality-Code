
namespace Minesweeper.Core.Commands
{
    using Events;
    using Interfaces;

    public class EndCommand : CommandAbstract
    {
        public EndCommand(IEngine engine)
            : base(engine)
        {

        }

        public override void Execute()
        {
            OnExecute(new CommandEventArgs() { Stopped = true });
            base.Engine.Writer.WriteLine("Bye, bye, bye!");
        }
    }
}
