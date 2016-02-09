
namespace Minesweeper.Core
{
    using System;
    using Commands;
    using Interfaces;

    public class CommandManager : ICommandManager
    {
        public IEngine Engine { get; set; }

        public IExecutable ManageCommand(string inputArgs)
        {
            IExecutable command = null;

            string commandType = inputArgs;

            switch (commandType)
            {
                case "top":
                    command = new StatusCommand(this.Engine);
                    break;
                case "restart":
                    command = new RestartCommand(this.Engine);
                    break;
                case "turn":
                    command = new TurnCommand(this.Engine);
                    break;
                case "exit":
                    command = new EndCommand(this.Engine);
                    break;
                default:
                    this.Engine.Writer.WriteLine("\nError! Invalid command\n");
                    break;
            }

            return command;
        }
    }
}
