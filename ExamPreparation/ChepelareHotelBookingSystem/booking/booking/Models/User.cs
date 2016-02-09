namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Interfaces;
    using Utilities;

    public class User : IDbEntity
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Roles role)
        {
            this.Username = username;
            this.PasswordHash = password;
            this.Role = role;
            this.Bookings = new HashSet<Booking>();
        }

        public Roles Role { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }

        public int Id { get; set; }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinimumUserNameLengthMsg)
                {
                    throw new ArgumentException(string.Format(Constants.UserNameLengthMsg, Constants.MinimumUserNameLengthMsg));
                }

                this.username = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinimumPasswordLengthMsg)
                {
                    throw new ArgumentException(string.Format(Constants.PasswordLengthMsg, Constants.MinimumPasswordLengthMsg));
                }

                this.passwordHash = HashUtilities.GetSha256Hash(value);
            }
        }
    }
}
