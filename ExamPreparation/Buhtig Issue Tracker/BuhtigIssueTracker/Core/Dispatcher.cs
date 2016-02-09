namespace BuhtigIssueTracker.Core
{
    using Enumerations;
    using Interfaces;

    public class Dispatcher : IDispatcher
    {
        private readonly IIssueTracker issueTracker;
        private readonly IUserTracker userTracker;

        public Dispatcher(IIssueTracker issueTracker, IUserTracker userTracker)
        {
            this.issueTracker = issueTracker;
            this.userTracker = userTracker;
        }

        public string DispatchAction(IEndpoint endpoint)
        {
            string result = string.Empty;

            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    result = this.RegisterUser(endpoint);
                    break;
                case "LoginUser":
                    result = this.LoginUser(endpoint);
                    break;
                case "LogoutUser":
                    result = this.LogoutUser();
                    break;
                case "CreateIssue":
                    result = this.CreateIssue(endpoint);
                    break;
                case "RemoveIssue":
                    result = this.RemoveIssue(endpoint);
                    break;
                case "AddComment":
                    result = this.AddComment(endpoint);
                    break;
                case "MyIssues":
                    result = this.MyIssues();
                    break;
                case "MyComments":
                    result = this.MyComments();
                    break;
                case "Search":
                    result = this.Search(endpoint);
                    break;
                default:
                    result = string.Format("Invalid action: {0}", endpoint.ActionName);
                    break;
            }

            return result;
        }

        private string RegisterUser(IEndpoint endpoint)
        {
            string result = this.userTracker.RegisterUser(
                endpoint.Parameters["username"],
                endpoint.Parameters["password"],
                endpoint.Parameters["confirmPassword"]);

            return result;
        }

        private string LoginUser(IEndpoint endpoint)
        {
            string result = this.userTracker.LoginUser(endpoint.Parameters["username"], endpoint.Parameters["password"]);

            return result;
        }

        private string LogoutUser()
        {
            string result = this.userTracker.LogoutUser();

            return result;
        }

        private string CreateIssue(IEndpoint endpoint)
        {
            string result = this.issueTracker.CreateIssue(endpoint.Parameters["title"], endpoint.Parameters["description"], (IssuePriorities)System.Enum.Parse(typeof(IssuePriorities), endpoint.Parameters["priority"], true), endpoint.Parameters["tags"].Split('|'));

            return result;
        }

        private string RemoveIssue(IEndpoint endpoint)
        {
            string result = this.issueTracker.RemoveIssue(int.Parse(endpoint.Parameters["id"]));

            return result;
        }

        private string AddComment(IEndpoint endpoint)
        {
            string result = this.issueTracker.AddComment(int.Parse(endpoint.Parameters["id"]), endpoint.Parameters["text"]);

            return result;
        }

        private string MyIssues()
        {
            string result = this.issueTracker.GetMyIssues();

            return result;
        }

        private string MyComments()
        {
            string result = this.userTracker.GetMyComments();

            return result;
        }

        private string Search(IEndpoint endpoint)
        {
            string result = this.issueTracker.SearchForIssues(endpoint.Parameters["tags"].Split('|'));

            return result;
        }
    }
}