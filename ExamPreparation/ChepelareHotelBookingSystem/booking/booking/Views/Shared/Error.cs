namespace HotelBookingSystem.Views.Shared
{
    using System.Text;
    using Infrastructure;
    using Utilities;

    public class Error : View
    {
        public Error(string message)
            : base(message)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var message = this.Model as string;
            viewResult.AppendLine(Constants.SometingHappendMsg)
                .AppendLine(message);
        }
    }
}
