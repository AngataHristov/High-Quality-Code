namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using Core;
    using Enumerations;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utilities;

   public class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityData data, User currentUser)
            : base(data, currentUser)
        {
        }

        /// <summary>
        /// Registers CurrentUser by given name, password, confirmed password and role
        /// </summary>
        /// <param name="username">The name of CurrentUser.</param>
        /// <param name="password">The password of CurrentUser.</param>
        /// <param name="confirmPassword">Password for confirm.</param>
        /// <param name="role">The role of the CurrentUser.</param>
        /// <returns>Returns view in case of success or throws ana exception.</returns>
        public IView Register(
            string username,
            string password,
            string confirmPassword,
            string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException(Constants.PasswordNotMatchMsg);
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format(Constants.UserAlreadyExistMsg, username));
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);

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
                throw new ArgumentException(string.Format(Constants.UserDoesNotExistMsg, username));
            }

            if (existingUser.Password != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException(Constants.WrongPasswordMsg);
            }

            this.CurrentUser = existingUser;
            return this.View(existingUser);
        }

        public IView Logout()
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Constants.NoCurrentlyLoggedUserMsg);
            }

            //if (!this.CurrentUser.IsInRole(Role.Lecturer) && !this.CurrentUser.IsInRole(Role.Student))
            //{
            //    throw new AuthorizationFailedException(Constants.NoAutorizedUserMsg);
            //}

            var user = this.CurrentUser;
            this.CurrentUser = null;

            return this.View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                throw new ArgumentException(Constants.AlreadyLoggedInUserMsg);
            }
        }
    }
}