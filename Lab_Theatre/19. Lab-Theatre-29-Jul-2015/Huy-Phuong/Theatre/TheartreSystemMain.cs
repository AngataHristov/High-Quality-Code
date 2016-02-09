namespace TheatreSystem
{
    using System.Globalization;
    using System.Threading;
    using Core;
    using Core.Engines;
    using Core.IO;
    using Interfaces;

    public class TheartreSystemMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            IPerformanceDatabase performanceDatabase = new PerformanceDatabase();
            ICommandManager commandManager = new CommandManager(performanceDatabase);
            IInputReader reader = new ConsoleReader();
            IOutputWriter writer = new ConsoleWriter
            {
                AutoFlush = true
            };

            IEngine engine = new TheatreSystemEngine(commandManager, reader, writer);

            engine.Run();
        }
    }
}
