namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Enumerations;
    using Utilities;

    public class User
    {
        private string userName;
        private string password;

        public User(string username, string password, Role role)
        {
            this.UserName = username;
            this.Password = password;
            this.Role = role;
            this.Courses = new HashSet<Course>();
        }

        public Role Role { get; private set; }

        public ISet<Course> Courses { get; private set; }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(Constants.UserNameLengthMsg);
                }

                this.userName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    throw new ArgumentException(Constants.PasswordLengthMsg);
                }

                var hashedPassword = HashUtilities.HashPassword(value);

                this.password = hashedPassword;
            }
        }

        public void AddCource(Course course)
        {
            this.Courses.Add(course);
        }
    }
}
