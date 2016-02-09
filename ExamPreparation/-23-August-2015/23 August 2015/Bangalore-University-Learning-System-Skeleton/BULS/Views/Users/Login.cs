namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;
    using Core;
    using Models;

    public class Login : View
    {
        public Login(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var userModel = this.Model as User;
            viewResult.AppendFormat(Constants.UserLoggedInSuccessfullyMsg,
                userModel.UserName).AppendLine();
        }
    }
}
