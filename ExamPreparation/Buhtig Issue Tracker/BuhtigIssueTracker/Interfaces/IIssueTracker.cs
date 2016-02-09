namespace BuhtigIssueTracker.Interfaces
{
    using Enumerations;

    /// <summary>
    /// Defines an issue tracker, holding methodes for create and remove issue,
    /// add comment, get issues and seaching for issue by given tags;
    /// </summary>
    public interface IIssueTracker
    {
        /// <summary>
        /// Creates an issue  by given title, description,
        /// priority and tags.
        /// </summary>
        /// <param name="title">The title of the issue.</param>
        /// <param name="description">The description of the issue.</param>
        /// <param name="priority">Issue's priority.</param>
        /// <param name="tags">Issue's tags.</param>
        /// <returns>"Issue created successfully" in case of success, or a
        /// messsage with the problem in case of fail.</returns>
        string CreateIssue(string title, string description, IssuePriorities priority, string[] tags);

        /// <summary>
        /// Removes an issue by given id.
        /// </summary>
        /// <param name="issueId">Issue's id.</param>
        /// <returns>"Issue removed" in case of success, or a
        /// messsage with the problem in case of fail.</returns>
        string RemoveIssue(int issueId);

        /// <summary>
        /// Adds a comment to issue by given 
        /// issue id and text.
        /// </summary>
        /// <param name="issueId">Issue's id.</param>
        /// <param name="text">The text of the comment.</param>
        /// <returns>"Comment added successfully to issue" in case of success, or a
        /// messsage with the problem in case of fail.</returns>
        string AddComment(int issueId, string text);

        /// <summary>
        /// Gets all issues to the currently logged in user.
        /// </summary>
        /// <returns>All issues to the currently logged in user on a separate lines, ordered by given criteria.
        /// If the are no comments, returns "No issues".</returns>
        string GetMyIssues();

        /// <summary>
        /// Gets all issues by given tags.
        /// </summary>
        /// <param name="tags">Tags for searching.</param>
        /// <returns>All issues by given tags on a separate lines, ordered by given criteria.
        /// Returns messsage with the problem in case of fail.</returns>
        string SearchForIssues(string[] tags);
    }
}