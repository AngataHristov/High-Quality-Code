namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;
    using Core;
    using Models;

    public class Register : View
    {
        public Register(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat(Constants.UserRegisteredSuccessfullyMsg, (this.Model as User).UserName).AppendLine();
        }
    }
}
