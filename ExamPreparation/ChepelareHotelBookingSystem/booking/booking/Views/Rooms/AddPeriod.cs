namespace HotelBookingSystem.Views.Rooms
{
    using System.Text;
    using Infrastructure;
    using Models;
    using Utilities;

    public class AddPeriod : View
    {
        public AddPeriod(Room room)
            : base(room)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var room = this.Model as Room;
            viewResult.AppendFormat(Constants.PeriodAddedToRoomMsg, room.Id).AppendLine();
        }
    }
}
