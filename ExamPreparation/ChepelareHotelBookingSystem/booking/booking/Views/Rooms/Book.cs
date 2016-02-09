namespace HotelBookingSystem.Views.Rooms
{
    using System.Text;
    using Infrastructure;
    using Models;
    using Utilities;

    public class Book : View
    {
        public Book(Booking booking)
            : base(booking)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var booking = this.Model as Booking;
            viewResult.AppendFormat(Constants.RoomBookedMsg, booking.StartBookDate, booking.EndBookDate, booking.TotalPrice).AppendLine();
        }
    }
}
