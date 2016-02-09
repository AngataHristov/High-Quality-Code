namespace BangaloreUniversityLearningSystem.Data
{
    using System.Linq;
    using Models;

    public class UsersRepository : Repository<User>
    {
        public User GetByUsername(string username)
        {
            return this.items
                   .FirstOrDefault(u => u.UserName == username);
        }
    }
}
