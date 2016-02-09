using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Core
{
    using Commands;
    using Interfaces;
    public class CommandManager : ICommandManager
    {
        public IEngine Engine { get; set; }

        public IExecutable ManageCommand(string[] inputArgs)
        {
            IExecutable command = null;

            switch (inputArgs[0])
            {
                case "build":
                    command = new BuildCommand(inputArgs[1], this.Engine);
                    break;
                case "skip":
                    command = new SkipCommand();
                    break;
                case "empire-status":
                    command = new StatusCommand(this.Engine);
                    break;
                case "armistice":
                    command = new EndCommand();
                    break;
            }

            return command;
        }
    }
}
