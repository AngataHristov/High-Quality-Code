
namespace Minesweeper.Core.Commands
{
    using Interfaces;

    public class TurnCommand : CommandAbstract
    {
        public TurnCommand(IEngine engine)
            : base(engine)
        {

        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
