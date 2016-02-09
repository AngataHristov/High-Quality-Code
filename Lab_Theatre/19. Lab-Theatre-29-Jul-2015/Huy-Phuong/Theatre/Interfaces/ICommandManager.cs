namespace TheatreSystem.Interfaces
{
    public interface ICommandManager
    {
        IExecutable ExecuteCommand(string line);
    }
}
