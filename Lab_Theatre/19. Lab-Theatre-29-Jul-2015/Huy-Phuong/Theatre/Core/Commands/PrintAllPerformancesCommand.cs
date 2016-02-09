namespace TheatreSystem.Core.Commands
{
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class PrintAllPerformancesCommand : AbstractCommand
    {
        public PrintAllPerformancesCommand(IPerformanceDatabase performanceDatabase)
             : base(performanceDatabase)
        {
        }

        public override string Execute()
        {
            var performances = this.PerformanceDatabase
                                   .ListAllPerformances()
                                   .ToList();

            var result = string.Empty;
            string dateTime = string.Empty;
            var stringBuilder = new StringBuilder();

            if (performances.Any())
            {
                stringBuilder.Append(result);

                for (int i = 0; i < performances.Count; i++)
                {

                    if (i > 0)
                    {
                        stringBuilder.Append(", ");
                    }

                    dateTime = performances[i].StartDateTime.ToString(Constants.DateTimeFormattingMsg);
                    stringBuilder.AppendFormat("({0}, {1}, {2})", performances[i].PerformanceTitle, performances[i].TheatreName, dateTime);
                }

                result = stringBuilder.ToString();
                return result;
            }

            return Constants.NoPerformancesMsg;
        }
    }
}
