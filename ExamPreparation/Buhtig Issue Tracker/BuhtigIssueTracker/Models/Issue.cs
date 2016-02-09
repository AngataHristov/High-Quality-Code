namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enumerations;
    using Interfaces;
    using Utilities;

    public class Issue
    {
        private string title;
        private string description;

        public Issue(string title, string description, IssuePriorities priority, IList<string> tags)
        {
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.Tags = tags;
            this.Comments = new List<IComment>();
        }

        public int Id { get; set; }

        public IssuePriorities Priority { get; set; }

        public IList<string> Tags { get; set; }

        public IList<IComment> Comments { get; set; }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.TitleMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.InvalidTitleLengthMsg, Constants.TitleMinLength));
                }

                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.DescriptionMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.InvalidDescriptionLengthMsg, Constants.DescriptionMinLength));
                }

                this.description = value;
            }
        }

        public void AddComment(IComment comment)
        {
            this.Comments.Add(comment);
        }

        public override string ToString()
        {
            StringBuilder issueInfo = new StringBuilder();
            issueInfo.AppendLine(this.Title)
                 .AppendFormat("Priority: {0}", this.GetPriorityAsString())
                 .AppendLine()
                 .AppendLine(this.Description);

            if (this.Tags.Count > 0)
            {
                issueInfo.AppendFormat("Tags: {0}", string.Join(",", this.Tags.OrderBy(t => t))).AppendLine();
            }

            if (this.Comments.Count > 0)
            {
                issueInfo.AppendFormat("Comments:{0}{1}", Environment.NewLine, string.Join(Environment.NewLine, this.Comments))
                         .AppendLine();
            }

            return issueInfo.ToString().Trim();
        }

        private string GetPriorityAsString()
        {
            switch (this.Priority)
            {
                case IssuePriorities.Showstopper:
                    return "****";
                case IssuePriorities.High:
                    return "***";
                case IssuePriorities.Medium:
                    return "**";

                case IssuePriorities.Low:
                    return "*";
                default:
                    throw new InvalidOperationException(Constants.InvalidProirityMsg);
            }
        }
    }
}