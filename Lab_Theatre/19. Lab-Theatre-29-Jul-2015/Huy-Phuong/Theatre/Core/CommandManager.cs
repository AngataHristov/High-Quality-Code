namespace TheatreSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Commands;
    using Interfaces;

    public class CommandManager : ICommandManager
    {
        private readonly IPerformanceDatabase performanceDatabase;

        public CommandManager(IPerformanceDatabase performanceDatabas)
        {
            this.performanceDatabase = performanceDatabas;
        }

        public IExecutable ExecuteCommand(string line)
        {
            string[] inputArgs = line.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputArgs[0];
            string[] parameters = inputArgs.Skip(1).Select(p => p.Trim()).ToArray();
            IExecutable commandResult = null;

            switch (command)
            {
                case "AddTheatre":
                    commandResult = new AddTheatreCommand(parameters, this.performanceDatabase);
                    break;
                case "PrintAllTheatres":
                    commandResult = new PrintAllTheatresCommand(this.performanceDatabase);
                    break;
                case "AddPerformance":
                    commandResult = new AddPerformanceCommand(parameters, this.performanceDatabase);
                    break;
                case "PrintAllPerformances":
                    commandResult = new PrintAllPerformancesCommand(this.performanceDatabase);
                    break;
                case "PrintPerformances":
                    commandResult = new PrintPerformancesCommand(parameters, this.performanceDatabase);
                    break;
                default:
                    commandResult = new InvalidResultCommand(this.performanceDatabase);
                    break;
            }

            return commandResult;
        }
    }
}