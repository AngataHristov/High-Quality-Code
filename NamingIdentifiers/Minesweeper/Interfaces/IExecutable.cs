
namespace Minesweeper.Interfaces
{
    using Events;

    public delegate void OnRunningChanged(object sender, CommandEventArgs args);

    public interface IExecutable
    {
        void Execute();

        IEngine Engine { get; }

        event OnRunningChanged OnExecuting;
    }
}
