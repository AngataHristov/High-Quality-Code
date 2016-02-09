namespace BangaloreUniversityLearningSystem.Interfaces
{
    public interface IEngine
    {
        IInputReader Reader { get; }

        IOutputWriter Writer { get; }

        void Run();
    }
}
