namespace HotelBookingSystem.Views.Users
{
    using System.Text;
    using Infrastructure;
    using Models;
    using Utilities;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult.AppendFormat(Constants.UserLoggedOutMsg, user.Username).AppendLine();
        }
    }
}
