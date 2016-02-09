
namespace Minesweeper.Interfaces
{
    public interface IEngine
    {
        ICommandManager CommandManager { get; }

        IInputReader Reader { get; }

        IOutputWriter Writer { get; }

        IDataBase DB { get; }

        void Run();
    }
}
