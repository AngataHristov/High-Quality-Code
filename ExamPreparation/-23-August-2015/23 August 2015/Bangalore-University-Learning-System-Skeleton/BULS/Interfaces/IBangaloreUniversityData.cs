namespace BangaloreUniversityLearningSystem.Interfaces
{
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Models;

    public interface IBangaloreUniversityData
    {
        IRepository<Course> Courses { get; }

        UsersRepository Users { get; }
    }
}