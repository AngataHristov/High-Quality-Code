namespace BangaloreUniversityLearningSystem.Interfaces
{
    using Data;

    public interface IBangaloreUniversityData
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}