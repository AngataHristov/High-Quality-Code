namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Text;
    using Interfaces;
    using Utilities;

    public class Comment : IComment
    {
        private string text;

        public Comment(IUser author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public IUser Author { get; private set; }

        public string Text
        {
            get
            {
                return this.text;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.TextMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.InvalidTextLengthMsg, Constants.TextMinLength));
                }

                this.text = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(this.Text)
                  .AppendFormat("-- {0}", this.Author.UserName)
                  .AppendLine();

            return result.ToString().Trim();
        }
    }
}