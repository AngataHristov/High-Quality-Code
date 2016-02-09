namespace HotelBookingSystem.Controllers
{
    using System;
    using Enums;
    using Interfaces;
    using Models;
    using Utilities;

    public class UsersController : Controller
    {
        public UsersController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException(Constants.NotMatchPasswordMsg);
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.UsersRepository.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format(Constants.UserAlreadyExistMsg, username));
            }

            Roles userRole = (Roles)Enum.Parse(typeof(Roles), role, true);
            var user = new User(username, password, userRole);
            this.Data.UsersRepository.Add(user);

            return this.View(user);
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.UsersRepository.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(string.Format(Constants.UserNotExistMsg, username));
            }

            if (existingUser.PasswordHash != HashUtilities.GetSha256Hash(password))
            {
                throw new ArgumentException(Constants.WrongPasswordMsg);
            }

            this.CurrentUser = existingUser;

            return this.View(existingUser);
        }

        public IView MyProfile()
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);
            return this.View(this.CurrentUser);
        }

        public IView Logout()
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);

            var user = this.CurrentUser;
            this.CurrentUser = null;

            return this.View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            var users = this.Data.UsersRepository.GetAll();
            foreach (var user in users)
            {
                if (this.CurrentUser != null && this.CurrentUser.Username == user.Username)
                {
                    throw new ArgumentException(Constants.AlreadyLoggedInUserMsg);
                }
            }
        }
    }
}
