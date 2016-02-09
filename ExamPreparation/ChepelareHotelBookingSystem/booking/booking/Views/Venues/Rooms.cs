namespace HotelBookingSystem.Views.Venues
{
    using System.Linq;
    using System.Text;
    using Infrastructure;
    using Models;
    using Utilities;

    public class Rooms : View
    {
        public Rooms(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendFormat(Constants.AvaliableRoomForVenueMsg, venue.Name).AppendLine();
            if (!venue.Rooms.Any())
            {
                viewResult.AppendFormat(Constants.NoRoomsAvailableMsg);
            }
            else
            {
                foreach (var room in venue.Rooms)
                {
                    viewResult.AppendFormat(" *[{0}] {1} places, ${2:F2} per day", room.Id, room.Places, room.PricePerDay).AppendLine();
                    if (!room.AvailableDates.Any())
                    {
                        viewResult.AppendLine(Constants.RoomNotCurrentlyAvaliableMsg);
                    }
                    else
                    {
                        viewResult.AppendLine("Available dates:");
                        foreach (var datePair in room.AvailableDates.OrderBy(datePair => datePair.EndDate))
                        {
                            viewResult.AppendFormat(" - {0:dd.MM.yyyy} - {1:dd.MM.yyyy}", datePair.StartDate, datePair.EndDate).AppendLine();
                        }
                    }
                }
            }
        }
    }
}
