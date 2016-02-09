namespace BuhtigIssueTracker.Data
{
    using System.Collections.Generic;
    using Interfaces;
    using Models;
    using Wintellect.PowerCollections;

    public class Database : IDatabase
    {
        private const int IssueIdDefault = 1;

        public Database()
        {
            this.NextIssueId = IssueIdDefault;
            this.Users = new Dictionary<string, IUser>();
            this.IssuesById = new OrderedDictionary<int, Issue>();
            this.IssuesByUserName = new MultiDictionary<string, Issue>(true);
            this.IssuesByTag = new MultiDictionary<string, Issue>(true);
            this.CommentsByUser = new MultiDictionary<IUser, IComment>(true);
        }

        public MultiDictionary<IUser, IComment> CommentsByUser { get; }

        public int NextIssueId { get; set; }

        public IUser CurrentlyLoggedInUser { get; set; }

        public IDictionary<string, IUser> Users { get; set; }

        public OrderedDictionary<int, Issue> IssuesById { get; set; }

        public MultiDictionary<string, Issue> IssuesByUserName { get; set; }

        public MultiDictionary<string, Issue> IssuesByTag { get; set; }
    }
}