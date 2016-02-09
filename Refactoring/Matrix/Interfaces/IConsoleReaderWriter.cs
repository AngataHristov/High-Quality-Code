namespace RotatingWalkInMatrix.Interfaces
{
    public interface IConsoleReaderWriter
    {
        string ReadNextLine();

        void Write(string line);

        void Flush();
    }
}
