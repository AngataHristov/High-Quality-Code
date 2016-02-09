
namespace Empires.Interfaces
{
    /// <summary>
    /// Distributes commands in the app
    /// </summary>
    public interface ICommandManager
    {
        // App engine
        IEngine Engine { get; set; }

        //Manages commands in the app
        IExecutable ManageCommand(string[] inputArgs);
    }
}
