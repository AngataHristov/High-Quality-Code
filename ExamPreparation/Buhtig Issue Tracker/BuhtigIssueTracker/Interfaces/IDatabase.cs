namespace BuhtigIssueTracker.Interfaces
{
    using System.Collections.Generic;
    using Models;
    using Wintellect.PowerCollections;

    public interface IDatabase
    {
        IUser CurrentlyLoggedInUser { get; set; }

        IDictionary<string, IUser> Users { get; }

        OrderedDictionary<int, Issue> IssuesById { get; }

        MultiDictionary<string, Issue> IssuesByUserName { get; }

        MultiDictionary<string, Issue> IssuesByTag { get; }

        MultiDictionary<IUser, IComment> CommentsByUser { get; }

        int NextIssueId { get; set; }
    }
}