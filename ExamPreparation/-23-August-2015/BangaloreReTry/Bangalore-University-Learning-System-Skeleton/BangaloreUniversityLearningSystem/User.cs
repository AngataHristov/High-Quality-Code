namespace BangaloreUniversityLearningSystem
{
    using System;
    using System.Collections.Generic;
    using Enumerations;
    using Utilities;

    public class User
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Role role)
        {
            if (username == null || username == string.Empty)
            {
                string message = string.Format("The username must be at least 5 symbols long.");
                throw new ArgumentException(message);
            }

            if (username.Length < 5)
            {
                string message = string.Format("The username must be at least 5 symbols long.");
                throw new ArgumentException(message);
            }

            this.UserName = username;

            if (password == null || password == string.Empty)
            {
                string message = string.Format("The password must be at least 5 symbols long.");
                throw new ArgumentException(message);
            }

            if (password.Length < 5)
            {
                string message = string.Format("The username must be at least 5 symbols long.");
                throw new ArgumentException(message);
            }

            string passwordHash = HashUtilities.HashPassword(password);
            this.Password = passwordHash;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}