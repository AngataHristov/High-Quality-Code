namespace TheatreSystem.Interfaces
{
    public interface IEngine
    {
        ICommandManager CommandManager { get; }

        IInputReader Reader { get; }

        IOutputWriter Writer { get; }

        void Run();
    }
}
