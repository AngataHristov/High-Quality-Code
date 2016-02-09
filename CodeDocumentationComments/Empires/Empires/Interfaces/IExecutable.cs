
namespace Empires.Interfaces
{
    using Core.Engines;

    public delegate void OnRunningChanged(object sender, CommandEventArgs args);

    /// <summary>
    /// Gives the possibility to execute
    /// </summary>
    public interface IExecutable
    {
        // Executes
        void Execute();

        // Listening for state's changes
        event OnRunningChanged OnExecuting;
    }
}
