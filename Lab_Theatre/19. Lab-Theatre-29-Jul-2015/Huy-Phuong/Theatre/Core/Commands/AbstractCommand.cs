namespace TheatreSystem.Core.Commands
{
    using Interfaces;

    public abstract class AbstractCommand : IExecutable
    {
        private readonly IPerformanceDatabase performanceDatabase;

        protected AbstractCommand(IPerformanceDatabase performanceDatabase)
        {
            this.performanceDatabase = performanceDatabase;
        }

        public IPerformanceDatabase PerformanceDatabase
        {
            get { return this.performanceDatabase; }
        }

        public abstract string Execute();
    }
}
