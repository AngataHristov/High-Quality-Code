
namespace Empires.Interfaces
{
    /// <summary>
    ///Responses for writting output data
    /// </summary>
    public interface IOutputWriter
    {
        // Write given string
        void Write(string line);

        // Clears the buffer
        void Flush();
    }
}
