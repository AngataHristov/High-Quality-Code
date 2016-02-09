using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Core.Engines
{
    public class CommandEventArgs : EventArgs
    {
        public bool Stopped;

        public int BuildingsCreatedCount = 0;
    }
}
