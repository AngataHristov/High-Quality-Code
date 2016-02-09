using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Core.Commands
{
    using Engines;
    using Interfaces;

    public class EndCommand : CommandAbstract
    {
        public EndCommand()
            : base(null)
        {

        }

        public override void Execute()
        {
            OnExecute(new CommandEventArgs() { Stopped = true});
        }
    }
}
