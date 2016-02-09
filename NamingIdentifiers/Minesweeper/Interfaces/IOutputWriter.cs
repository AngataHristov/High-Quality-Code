
namespace Minesweeper.Interfaces
{
    public interface IOutputWriter
    {
        void WriteLine(string line);

        void Write(string line);

        void Flush();
    }
}
