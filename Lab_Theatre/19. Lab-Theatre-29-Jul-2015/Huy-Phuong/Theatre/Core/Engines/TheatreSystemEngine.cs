namespace TheatreSystem.Core.Engines
{
    using System;
    using Interfaces;

    public class TheatreSystemEngine : IEngine
    {
        private readonly ICommandManager commandManager;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public TheatreSystemEngine(ICommandManager commandManager, IInputReader reader, IOutputWriter writer)
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

        public virtual void Run()
        {
            while (true)
            {
                string inputLine = this.Reader.ReadNextLine();
                if (inputLine == null)
                {
                    break;
                }

                if (inputLine.Length < 1)
                {
                    continue;
                }

                try
                {
                    IExecutable commandResult = commandManager.ExecuteCommand(inputLine);
                    if (commandResult != null)
                    {
                        this.Writer.Write(commandResult.Execute());
                    }
                }
                catch (Exception ex)
                {
                    this.writer.Write("Error: " + ex.Message);
                }
            }
        }
    }
}
