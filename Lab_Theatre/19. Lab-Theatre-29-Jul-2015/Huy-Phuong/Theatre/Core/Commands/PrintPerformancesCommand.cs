namespace TheatreSystem.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class PrintPerformancesCommand : AbstractCommand
    {
        private string[] parameters;

        public PrintPerformancesCommand(string[] inputArgs, IPerformanceDatabase performanceDatabase)
            : base(performanceDatabase)
        {
            this.parameters = inputArgs;
        }

        public override string Execute()
        {
            string commandResult = string.Empty;

            var performances = this.FindPerformances(parameters[0]).
                       Select(p =>
                       {
                           string time = p.StartDateTime.ToString(Constants.DateTimeFormattingMsg);
                           return string.Format("({0}, {1})", p.PerformanceTitle, time);
                       }).ToList();

            if (performances.Any())
            {
                commandResult = string.Join(", ", performances);
            }
            else
            {
                commandResult = Constants.NoPerformancesMsg;
            }

            return commandResult;
        }

        private IEnumerable<Performance> FindPerformances(string theatre)
        {
            IEnumerable<Performance> performances = this.PerformanceDatabase.ListPerformances(theatre);
            return performances;
        }
    }
}
