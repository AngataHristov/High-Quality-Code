using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Core.Engines
{
    using Interfaces;

    public class EmpiresEngine : IEngine
    {
        private bool isStarted;
        private readonly IDataBase db;
        private readonly ICommandManager commandManager;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public EmpiresEngine(IDataBase db, ICommandManager commandManager, IInputReader reader, IOutputWriter writer)
        {
            this.db = db;
            this.commandManager = commandManager;
            this.commandManager.Engine = this;
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

        public IDataBase DB
        {
            get { return this.db; }            
        }     

        public void Run()
        {
            this.isStarted = true;

            IExecutable command = null;

            while (this.isStarted)
            {
                string line = this.reader.ReadNextLine();
                string[] inputArgs = line.Split(' ');

                command = this.commandManager.ManageCommand(inputArgs);

                try
                {
                    command.OnExecuting += (sender, args) =>
                    {
                        this.isStarted = !args.Stopped;
                    };
                    command.Execute();

                }
                catch (Exception e)
                {
                    this.writer.Write(e.Message);
                }
                
                UpdateStats();
            }
        }

        private void UpdateStats()
        {
            foreach (var building in this.db.AllBuildings)
            {
                building.Update();
            }
        }

    }
}
