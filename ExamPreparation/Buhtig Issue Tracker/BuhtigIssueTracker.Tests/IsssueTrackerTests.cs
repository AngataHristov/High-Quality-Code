namespace BuhtigIssueTracker.Tests
{
    using System.Runtime.CompilerServices;
    using System.Text;
    using Core.Trackers;
    using Data;
    using Enumerations;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Utilities;

    [TestClass]
    public class IsssueTrackerTests
    {
        private IDatabase database;
        private IIssueTracker issueTracker;
        private IUserTracker userTracker;

        [TestInitialize]
        public void Initialize()
        {
            this.database = new Database();
            this.issueTracker = new IssueTracker(this.database);
            this.userTracker = new UserTracker(this.database);
        }

        [TestMethod]
        public void TestCreateIssue_NoCurrentlyLoggedInUser_ShouldReturnCorrectMessage()
        {
            string message = this.issueTracker.CreateIssue("something", "no descriptions", IssuePriorities.Low,
                new[] { "new", "issue" });
            string expectedMessage = Constants.NoCurrentlyLogedinUserMsg;

            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod]
        public void TestCreateIssue_WithLoggedInUser_ShouldReturnCorrectMessage()
        {
            this.userTracker.RegisterUser("peshko", "123456", "123456");
            this.userTracker.LoginUser("peshko", "123456");

            string message = this.issueTracker.CreateIssue("something", "no descriptions", IssuePriorities.Low,
                new[] { "new", "issue" });
            string expectedMessage = string.Format(Constants.IssueCreatedSuccessfullyMsg, 1);
            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod]
        public void TestCreateIssue_WithLoggedInUser_ShouldReturnCorrectIssueId()
        {
            this.userTracker.RegisterUser("peshko", "123456", "123456");
            this.userTracker.LoginUser("peshko", "123456");
            this.issueTracker.CreateIssue("something", "no descriptions", IssuePriorities.Low, new[] { "new", "issue" });

            int expectedId = 2;
            int id = this.database.NextIssueId;
            Assert.AreEqual(expectedId, id);
        }

        [TestMethod]
        public void TestCreateIssue_WithLoggedInUser_ShouldIncreaceIssuesByIdCount()
        {
            this.userTracker.RegisterUser("peshko", "123456", "123456");
            this.userTracker.LoginUser("peshko", "123456");
            this.issueTracker.CreateIssue("something", "no descriptions", IssuePriorities.Low, new[] { "new", "issue" });

            int expectedIssuesByIdCount = 1;
            int IssuesByIdCount = this.database.IssuesById.Count;

            Assert.AreEqual(expectedIssuesByIdCount, IssuesByIdCount);
        }

        [TestMethod]
        public void TestCreateIssue_WithLoggedInUser_ShouldIncreaceIssuesByUserNameCount()
        {
            this.userTracker.RegisterUser("peshko", "123456", "123456");
            this.userTracker.LoginUser("peshko", "123456");
            this.issueTracker.CreateIssue("something", "no descriptions", IssuePriorities.Low, new[] { "new", "issue" });

            int expectedIssuesByUserNameCount = 1;
            int IssuesByUserNameCount = this.database.IssuesByUserName["peshko"].Count;

            Assert.AreEqual(expectedIssuesByUserNameCount, IssuesByUserNameCount);
        }

        [TestMethod]
        public void TestGetMyIssues_NoCurrentlyLoggedInUser_ShouldReturnCorrectMessage()
        {
            this.issueTracker.CreateIssue("something", "no descriptions", IssuePriorities.Low, new[] { "new", "issue" });
            string message = this.issueTracker.GetMyIssues();
            string expectedMessage = Constants.NoCurrentlyLogedinUserMsg;

            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod]
        public void TestGetMyIssues_NoCreatedIssues_ShouldReturnCorrectMessage()
        {
            this.userTracker.RegisterUser("peshko", "123456", "123456");
            this.userTracker.LoginUser("peshko", "123456");

            string message = this.issueTracker.GetMyIssues();
            string expectedMessage = Constants.NoIssuesMsg;

            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod]
        public void TestGetMyIssues_WithLoggedInUser_ShouldReturnCorrectMessage()
        {
            this.userTracker.RegisterUser("peshko", "123456", "123456");
            this.userTracker.LoginUser("peshko", "123456");
            this.issueTracker.CreateIssue("something", "no descriptions", IssuePriorities.Low, new[] { "new", "issue" });

            string message = this.issueTracker.GetMyIssues();

            StringBuilder expectedMessage = new StringBuilder();
            expectedMessage
                .AppendLine("something")
                .AppendLine("Priority: *")
                .AppendLine("no descriptions")
                .AppendLine("Tags: issue,new");

            Assert.AreEqual(expectedMessage.ToString().Trim(), message);
        }

        [TestMethod]
        public void TestSearchForIssues_NoTags_ShouldReturnCorrectMessage()
        {
            string message = this.issueTracker.SearchForIssues(new string[0]);
            string expectedMessage = Constants.NoTagsProvidedMsg;

            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod]
        public void TestSearchForIssues_WithIssuesAndTags_ShouldReturnCorrectMessage()
        {
            this.userTracker.RegisterUser("peshko", "123456", "123456");
            this.userTracker.LoginUser("peshko", "123456");
            this.issueTracker.CreateIssue("something", "no descriptions", IssuePriorities.Low, new[] { "new", "issue" });

            string message = this.issueTracker.SearchForIssues(new[] { "new", "issue" });

            StringBuilder expectedMessage = new StringBuilder();
            expectedMessage
                .AppendLine("something")
                .AppendLine("Priority: *")
                .AppendLine("no descriptions")
                .AppendLine("Tags: issue,new");

            Assert.AreEqual(expectedMessage.ToString().Trim(), message);
        }

        [TestMethod]
        public void TestSearchForIssues_WithManyIssuesAndTags_ShouldReturnCorrectMessage()
        {
            this.userTracker.RegisterUser("peshko", "123456", "123456");
            this.userTracker.LoginUser("peshko", "123456");
            this.issueTracker.CreateIssue("something", "no descriptions", IssuePriorities.Low, new[] { "new", "issue" });
            this.issueTracker.CreateIssue("something", "no descriptions", IssuePriorities.High, new[] { "new", "issue" });

            string message = this.issueTracker.SearchForIssues(new[] { "new", "issue" });

            StringBuilder expectedMessage = new StringBuilder();
            expectedMessage
                .AppendLine("something")
                .AppendLine("Priority: ***")
                .AppendLine("no descriptions")
                .AppendLine("Tags: issue,new")
                .AppendLine("something")
                .AppendLine("Priority: *")
                .AppendLine("no descriptions")
                .AppendLine("Tags: issue,new");

            Assert.AreEqual(expectedMessage.ToString().Trim(), message);
        }

        [TestMethod]
        public void TestSearchForIssues_NoMachingTags_ShouldReturnCorrectMessage()
        {
            this.userTracker.RegisterUser("peshko", "123456", "123456");
            this.userTracker.LoginUser("peshko", "123456");
            this.issueTracker.CreateIssue("something", "no descriptions", IssuePriorities.Low, new[] { "new", "issue" });

            string message = this.issueTracker.SearchForIssues(new[] { "lqlql", "trakala" });
            string expectedMessage = Constants.NoIssuesMatchingTheTagProvidedMsg;

            Assert.AreEqual(expectedMessage, message);
        }
    }
}
