namespace TheatreSystem.Core.Commands
{
    using Interfaces;

    public class AddTheatreCommand : AbstractCommand
    {
        private string[] parameters;

        public AddTheatreCommand(string[] inputArgs, IPerformanceDatabase performanceDatabase)
            : base(performanceDatabase)
        {
            this.parameters = inputArgs;
        }

        public override string Execute()
        {
            string theatreName = parameters[0];
            this.PerformanceDatabase.AddTheatre(theatreName);
            return Constants.TheatreAddedMsg;
        }
    }
}
