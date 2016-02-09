namespace BangaloreUniversityLearningSystem.Data
{
    using Interfaces;

    public class BangaloreUniversityData : IBangaloreUniversityData
    {
        public UsersRepository Users { get; internal set; }

        public IRepository<Course> Courses { get; protected set; }

        public BangaloreUniversityData()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }
    }
}
