namespace TheatreSystem.Core.Commands
{
    using System;
    using System.Globalization;
    using Interfaces;

    public class AddPerformanceCommand : AbstractCommand
    {
        private string[] parameters;

        public AddPerformanceCommand(string[] inputArgs, IPerformanceDatabase performanceDatabase)
            : base(performanceDatabase)
        {
            this.parameters = inputArgs;
        }

        public override string Execute()
        {
            string theatreName = this.parameters[0];
            string performanceTitle = this.parameters[1];
            DateTime startDateTime = DateTime.ParseExact(this.parameters[2], Constants.DateTimeFormattingMsg, CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse(parameters[3]);
            decimal price = decimal.Parse(parameters[4], NumberStyles.Float);
            this.PerformanceDatabase.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
            return Constants.PerformancesAddedMsg;
        }
    }
}
