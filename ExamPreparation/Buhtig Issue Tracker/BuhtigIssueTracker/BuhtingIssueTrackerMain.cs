namespace BuhtigIssueTracker
{
    using System.Globalization;
    using System.Threading;

    using Core;
    using Core.IO;
    using Core.Trackers;
    using Data;
    using Interfaces;

    public class BuhtingIssueTrackerMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            IDatabase database = new Database();

            IUserTracker userTracker = new UserTracker(database);

            IIssueTracker issueTracker = new IssueTracker(database);

            IDispatcher dispatcher = new Dispatcher(issueTracker, userTracker);

            IInputReader reader = new ConsoleReader();

            IOutputWriter writer = new ConsoleWriter
            {
                AutoFlush = true
            };

            IEngine engine = new Engine(dispatcher, reader, writer);
            engine.Run();
        }
    }
}