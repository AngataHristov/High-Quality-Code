namespace BuhtigIssueTracker.Core.Trackers
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Interfaces;
    using Models;
    using Utilities;

    public class UserTracker : Tracker, IUserTracker
    {
        public UserTracker(IDatabase data)
             : base(data)
        {
        }

        public UserTracker()
            : this(new Database())
        {
        }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.Data.CurrentlyLoggedInUser != null)
            {
                return Constants.AlreadyLogedinUserMsg;
            }

            if (password != confirmPassword)
            {
                return Constants.ProvidedPasswordNotMatchMsg;
            }

            if (this.Data.Users.ContainsKey(username))
            {
                return string.Format(Constants.UserWithUserNameAlreadyExistMsg, username);
            }

            IUser user = new User(username, password);

            this.Data.Users.Add(username, user);

            return string.Format(Constants.UserRegisteredSuccessfullyMsg, username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.Data.CurrentlyLoggedInUser != null)
            {
                return Constants.AlreadyLogedinUserMsg;
            }

            if (!this.Data.Users.ContainsKey(username))
            {
                return string.Format(Constants.UserWithUserNameNotExistMsg, username);
            }

            var user = this.Data.Users[username];
            if (user.HashedPassword != HashUtilities.HashPassword(password))
            {
                return string.Format(Constants.InvalidPasswordForUserMsg, username);
            }

            this.Data.CurrentlyLoggedInUser = user;

            return string.Format(Constants.UserLogedInSuccessfullyMsg, username);
        }

        public string LogoutUser()
        {
            if (this.Data.CurrentlyLoggedInUser == null)
            {
                return Constants.NoCurrentlyLogedinUserMsg;
            }

            string username = this.Data.CurrentlyLoggedInUser.UserName;

            this.Data.CurrentlyLoggedInUser = null;

            return string.Format(Constants.UserLogedoutSuccessfullyMsg, username);
        }

        public string GetMyComments()
        {
            if (this.Data.CurrentlyLoggedInUser == null)
            {
                return Constants.NoCurrentlyLogedinUserMsg;
            }

            //List<IComment> comments = new List<IComment>();
            //this.Data.IssuesById
            //    .Select(i => i.Value.Comments)
            //    .ToList()
            //    .ForEach(item => comments.AddRange(item));

            var resultComments = this.Data.CommentsByUser[this.Data.CurrentlyLoggedInUser];

            var result = resultComments
                .Select(x => x.ToString());

            if (!result.Any())
            {
                return Constants.NoCommentsMsg;
            }

            return string.Join(Environment.NewLine, result);
        }
    }
}
