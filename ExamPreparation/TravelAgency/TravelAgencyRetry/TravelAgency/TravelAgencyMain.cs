
namespace TravelAgency
{
    using Core;
    using Interfaces;
    using IO.Core;

    public class TravelAgencyMain
    {
        public static void Main()
        {
            ITicketCatalog catalog = new TicketCatalog();

            ICommandManager commandManager = new CommandManager(catalog);

            IInputReader reader = new ConsoleReader();

            IOutputWriter writer = new ConsoleWriter
            {
                AutoFlush = true
            };

            IEngine engine = new Engine(commandManager, reader, writer);

            engine.Run();
        }
    }
}
