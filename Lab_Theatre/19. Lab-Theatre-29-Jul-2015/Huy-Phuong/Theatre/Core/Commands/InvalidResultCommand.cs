namespace TheatreSystem.Core.Commands
{
    using Interfaces;

    public class InvalidResultCommand : AbstractCommand
    {
        public InvalidResultCommand(IPerformanceDatabase performanceDatabase)
            : base(null)
        {
        }

        public override string Execute()
        {
            return Constants.InvalidCommandMsg;
        }
    }
}
