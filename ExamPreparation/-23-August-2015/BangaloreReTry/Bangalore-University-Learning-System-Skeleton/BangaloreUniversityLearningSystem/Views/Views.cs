namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }
        protected override void BuildViewResult(StringBuilder viewResult)
        {
            // TODO: Implement me
        }
    }

    public class Register : View
    {
        public Register(User user)
            : base(user)
        {
        }
        protected override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} registered successfully.", (this.Model as User).UserName).AppendLine();
        }
    }
}