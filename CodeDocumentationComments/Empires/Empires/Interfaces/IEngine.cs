using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Interfaces
{
    /// <summary>
    /// App engine
    /// </summary>
    public interface IEngine
    {
        // Manage commands
        ICommandManager CommandManager { get; }

        // Reads the input data
        IInputReader Reader { get; }

        // Writes output data
        IOutputWriter Writer { get; }

        // App repository
        IDataBase DB { get; }

        // Starts the application
        void Run();
    }
}
