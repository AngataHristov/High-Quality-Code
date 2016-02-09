namespace BuhtigIssueTracker.Core.Trackers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Enumerations;
    using Interfaces;
    using Models;
    using Utilities;

    public class IssueTracker : Tracker, IIssueTracker
    {
        public IssueTracker(IDatabase data)
              : base(data)
        {
        }

        public IssueTracker()
            : this(new Database())
        {
        }

        public string CreateIssue(string title, string description, IssuePriorities priority, string[] strings)
        {
            if (this.Data.CurrentlyLoggedInUser == null)
            {
                return Constants.NoCurrentlyLogedinUserMsg;
            }

            Issue issue = new Issue(title, description, priority, strings.Distinct().ToList());
            issue.Id = this.Data.NextIssueId;

            this.Data.IssuesById.Add(issue.Id, issue);
            this.Data.NextIssueId++;
            this.Data.IssuesByUserName[this.Data.CurrentlyLoggedInUser.UserName].Add(issue);

            foreach (var tag in issue.Tags)
            {
                this.Data.IssuesByTag[tag].Add(issue);
            }

            return string.Format(Constants.IssueCreatedSuccessfullyMsg, issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.Data.CurrentlyLoggedInUser == null)
            {
                return Constants.NoCurrentlyLogedinUserMsg;
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format(Constants.NoIssuesWithIdMsg, issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            if (!this.Data.IssuesByUserName[this.Data.CurrentlyLoggedInUser.UserName].Contains(issue))
            {
                return string.Format(Constants.IssueNotBelongToUserMsg, issueId, this.Data.CurrentlyLoggedInUser.UserName);
            }

            this.Data.IssuesByUserName[this.Data.CurrentlyLoggedInUser.UserName].Remove(issue);

            foreach (var tag in issue.Tags)
            {
                this.Data.IssuesByTag[tag].Remove(issue);
            }

            this.Data.IssuesById.Remove(issue.Id);

            return string.Format(Constants.IssueRemovedMsg, issueId);
        }

        public string AddComment(int issueId, string text)
        {
            if (this.Data.CurrentlyLoggedInUser == null)
            {
                return Constants.NoCurrentlyLogedinUserMsg;
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format(Constants.NoIssuesWithIdMsg, issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            IComment comment = new Comment(this.Data.CurrentlyLoggedInUser, text);
            issue.AddComment(comment);
            this.Data.CommentsByUser[this.Data.CurrentlyLoggedInUser].Add(comment);

            return string.Format(Constants.CommentAddedSuccessfullyToIssueMsg, issue.Id);
        }

        public string GetMyIssues()
        {
            if (this.Data.CurrentlyLoggedInUser == null)
            {
                return Constants.NoCurrentlyLogedinUserMsg;
            }

            var issues = this.Data.IssuesByUserName[this.Data.CurrentlyLoggedInUser.UserName];
            if (!issues.Any())
            {
                return Constants.NoIssuesMsg;
            }

            return string.Join(Environment.NewLine, issues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length <= 0)
            {
                return Constants.NoTagsProvidedMsg;
            }

            var issues = new List<Issue>();
            foreach (var t in tags)
            {
                issues.AddRange(this.Data.IssuesByTag[t]);
            }

            if (!issues.Any())
            {
                return Constants.NoIssuesMatchingTheTagProvidedMsg;
            }

            var uniqueIssues = issues.Distinct();
            if (!uniqueIssues.Any())
            {
                return Constants.NoIssuesMsg;
            }

            return string.Join(Environment.NewLine, uniqueIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }
    }
}
