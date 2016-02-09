namespace BangaloreUniversityLearningSystem.Interfaces
{
    public interface IOutputWriter
    {
        void Write(string line);

        void Flush();
    }
}
