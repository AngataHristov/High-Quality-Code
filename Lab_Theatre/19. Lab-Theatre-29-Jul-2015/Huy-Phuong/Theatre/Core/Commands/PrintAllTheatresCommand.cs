namespace TheatreSystem.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class PrintAllTheatresCommand : AbstractCommand
    {
        public PrintAllTheatresCommand(IPerformanceDatabase performanceDatabase)
            : base(performanceDatabase)
        {
        }

        public override string Execute()
        {
            var theatresCount = this.PerformanceDatabase
                                    .ListTheatres()
                                    .Count();
            if (theatresCount > 0)
            {
                var resultTheatres = new List<string>();
                this.PerformanceDatabase.ListTheatres()
                    .ToList()
                    .ForEach(t => resultTheatres.Add(t));
                

                return string.Join(", ", resultTheatres);
            }

            return Constants.NoTheatresMsg;
        }
    }
}
