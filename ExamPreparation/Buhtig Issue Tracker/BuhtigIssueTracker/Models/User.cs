namespace BuhtigIssueTracker.Models
{
    using Interfaces;
    using Utilities;

    public class User : IUser
    {
        private string hashedpaswor;

        public User(string username, string password)
        {
            this.UserName = username;
            this.HashedPassword = password;
        }

        public string UserName { get; private set; }

        public string HashedPassword
        {
            get
            {
                return this.hashedpaswor;
            }

            private set
            {
                this.hashedpaswor = HashUtilities.HashPassword(value);
            }
        }
    }
}