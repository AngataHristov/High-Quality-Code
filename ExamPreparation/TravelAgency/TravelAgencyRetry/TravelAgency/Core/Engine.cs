
namespace TravelAgency
{
    using System;
    using Interfaces;

    public class Engine : IEngine
    {
        private readonly ICommandManager commandManager;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public Engine(ICommandManager commandManager, IInputReader reader, IOutputWriter writer)
        {
            this.commandManager = commandManager;
            this.reader = reader;
            this.writer = writer;
        }

        public ICommandManager CommandManager
        {
            get { return this.commandManager; }
        }

        public IInputReader Reader
        {
            get { return this.reader; }
        }

        public IOutputWriter Writer
        {
            get { return this.writer; }
        }

        public void Run()
        {
            while (true)
            {
                string line = this.Reader.ReadNextLine();
                if (line == null)
                {
                    break;
                }

                line = line.Trim();

                string commandResult = commandManager.ExecuteCommand(line);
                if (commandResult != null)
                {
                    this.Writer.Write(commandResult);
                }
            }
        }
    }
}
