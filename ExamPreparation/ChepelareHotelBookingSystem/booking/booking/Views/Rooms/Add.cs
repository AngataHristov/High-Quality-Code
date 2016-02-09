namespace HotelBookingSystem.Views.Rooms
{
    using System.Text;
    using Infrastructure;
    using Models;
    using Utilities;

    public class Add : View
    {
        public Add(Room room)
            : base(room)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var room = this.Model as Room;
            viewResult.AppendFormat(Constants.RoomCreatedMsg, room.Id).AppendLine();
        }
    }
}
