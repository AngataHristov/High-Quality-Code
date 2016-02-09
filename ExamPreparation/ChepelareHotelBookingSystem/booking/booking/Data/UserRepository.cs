namespace HotelBookingSystem.Data
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Models;
    using Utilities;

    public class UserRepository : Repository<User>, IUserRepository
    {
        private IDictionary<string, User> usersByUsername;

        public UserRepository()
        {
            this.usersByUsername = new Dictionary<string, User>();
        }

        public User GetByUsername(string username)
        {
            if (!this.usersByUsername.ContainsKey(username))
            {
                return null;
            }

            return this.usersByUsername[username];
        }

        public override void Add(User user)
        {
            this.usersByUsername.Add(user.Username, user);
            base.Add(user);
        }
    }
}
