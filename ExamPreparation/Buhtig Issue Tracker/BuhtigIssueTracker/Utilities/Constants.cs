namespace BuhtigIssueTracker.Utilities
{
    public static class Constants
    {
        #region
        public const int TextMinLength = 2;
        public const int TitleMinLength = 3;
        public const int DescriptionMinLength = 5;
        #endregion

        #region
        public const string NoCurrentlyLogedinUserMsg = "There is no currently logged in user";
        public const string AlreadyLogedinUserMsg = "There is already a logged in user";
        public const string NoIssuesMsg = "No issues";
        public const string NoIssuesMatchingTheTagProvidedMsg = "There are no issues matching the tags provided";
        public const string NoTagsProvidedMsg = "There are no tags provided";
        public const string CommentAddedSuccessfullyToIssueMsg = "Comment added successfully to issue {0}";
        public const string NoIssuesWithIdMsg = "There is no issue with ID {0}";
        public const string IssueRemovedMsg = "Issue {0} removed";
        public const string IssueNotBelongToUserMsg = "The issue with ID {0} does not belong to user {1}";
        public const string NoIssueWithIdMsg = "There is no issue with ID {0}";
        public const string IssueCreatedSuccessfullyMsg = "Issue {0} created successfully";
        #endregion

        #region
        public const string NoCommentsMsg = "No comments";
        public const string UserLogedoutSuccessfullyMsg = "User {0} logged out successfully";
        public const string UserLogedInSuccessfullyMsg = "User {0} logged in successfully";
        public const string InvalidPasswordForUserMsg = "The password is invalid for user {0}";
        public const string UserWithUserNameNotExistMsg = "A user with username {0} does not exist";
        public const string UserRegisteredSuccessfullyMsg = "User {0} registered successfully";
        public const string UserWithUserNameAlreadyExistMsg = "A user with username {0} already exists";
        public const string ProvidedPasswordNotMatchMsg = "The provided passwords do not match";
        #endregion

        #region
        public const string InvalidProirityMsg = "The priority is invalid";
        public const string InvalidDescriptionLengthMsg = "The description must be at least {0} symbols long";
        public const string InvalidTitleLengthMsg = "The title must be at least {0} symbols long";
        public const string InvalidTextLengthMsg = "The text must be at least {0} symbols long";
        #endregion
    }
}
