namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;
    using Core;
    using Models;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var userModel = this.Model as User;
            viewResult.AppendFormat(Constants.UserLoggedOutSuccessfullyMsg,
                userModel.UserName).AppendLine();
        }
    }
}
