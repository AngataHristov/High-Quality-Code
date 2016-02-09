
namespace Empires
{
    using Core;
    using Core.Engines;
    using Interfaces;

    public class EmpiresMain
    {
        public static void Main()
        {
            IDataBase db = new DataBase();

            ICommandManager commandManager = new CommandManager();

            IInputReader reader = new ConsoleReader();

            IOutputWriter writer = new ConsoleWriter
            {
                AutoFlush = true
            };

            IEngine engine = new EmpiresEngine(db, commandManager, reader, writer);

            engine.Run();
        }
    }
}
