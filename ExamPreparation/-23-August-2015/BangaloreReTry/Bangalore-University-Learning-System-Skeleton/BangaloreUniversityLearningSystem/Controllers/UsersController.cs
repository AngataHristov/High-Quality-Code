namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using Enumerations;
    using Infrastructure;
    using Interfaces;
    using Utilities;

    class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityData data, User user)
        {
            this.Data = data;
            this.usr = user;
        }

        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("The provided passwords do not match.");
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format("A user with username {0} already exists.", username));
            }

            Role userRole = (Role) Enum.Parse(typeof (Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.Users.Add(user);
            return this.View(user);
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(string.Format("A user with username {0} does not exist.", username));
            }

            if (existingUser.Password != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException("The provided password is wrong.");
            }
            this.usr = existingUser;
            return this.View(existingUser);
        }

        public IView Logout()
        {
            if (!this.HasCurrentUser)
                throw new ArgumentException("There is no currently logged in user.");

            if (!this.usr.IsInRole(Role.Lecturer) && !this.usr.IsInRole(Role.Student))
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");

            var user = this.usr;
            this.usr = null;
            return this.View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                throw new ArgumentException("There is already a logged in user.");
            }
        }
    }
}