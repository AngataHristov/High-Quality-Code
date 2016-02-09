namespace BuhtigIssueTracker.Interfaces
{
    /// <summary>
    /// Defines an user tracker, holding methodes for
    /// regist, login, logout user and for giving comments.
    /// </summary>
    public interface IUserTracker
    {
        /// <summary>
        /// Registers an user by given username, password
        /// and password for confirming.
        /// </summary>
        /// <param name="username">The name of user.</param>
        /// <param name="password">The password of user.</param>
        /// <param name="confirmPassword">Password for confirming.</param>
        /// <returns>"User registered successfully" in case of success, or a
        /// messsage with the problem in case of fail.</returns>
        string RegisterUser(string username, string password, string confirmPassword);

        /// <summary>
        /// Logs in user by given username and password.
        /// </summary>
        /// <param name="username">The name of user.</param>
        /// <param name="password">The password of user.</param>
        /// <returns>"User logged in successfully" in case of success, or a
        /// messsage with the problem in case of fail.</returns>
        string LoginUser(string username, string password);

        /// <summary>
        /// Logs out, if the is logged in user.
        /// </summary>
        /// <returns>"User logged out successfully" in case of success, or a
        /// messsage with the problem in case of fail.</returns>
        string LogoutUser();

        /// <summary>
        /// Gets all comments to the currently logged in user.
        /// </summary>
        /// <returns>All comments to the currently logged in user on a separate lines.
        /// If the are no comments, returns "No comments".</returns>
        string GetMyComments();
    }
}
