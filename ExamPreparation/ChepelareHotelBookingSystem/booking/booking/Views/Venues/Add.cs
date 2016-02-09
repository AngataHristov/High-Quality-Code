namespace HotelBookingSystem.Views.Venues
{
    using System.Text;
    using Infrastructure;
    using Models;
    using Utilities;

    public class Add : View
    {
        public Add(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendFormat(Constants.VenueCreatedMsg, venue.Name, venue.Id).AppendLine();
        }
    }
}
