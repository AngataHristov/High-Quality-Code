namespace HotelBookingSystem.Views.Users
{
    using System.Text;
    using Infrastructure;
    using Models;
    using Utilities;

    public class Register : View
    {
        public Register(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult
                .AppendFormat(Constants.RegisteredUserMsg, user.Username)
                .AppendLine();
        }
    }
}
