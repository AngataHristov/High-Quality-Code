namespace HotelBookingSystem.Data
{
    using Interfaces;
    using Models;

    public class HotelBookingSystemData : IHotelBookingSystemData
    {
        public HotelBookingSystemData()
        {
            this.UsersRepository = new UserRepository();
            this.VenuesRepository = new Repository<Venue>();
            this.RoomsRepository = new Repository<Room>();
            this.BookingRepository = new Repository<Booking>();
        }

        public IUserRepository UsersRepository { get; private set; }

        public IRepository<Venue> VenuesRepository { get; set; }

        public IRepository<Room> RoomsRepository { get; set; }

        public IRepository<Booking> BookingRepository { get; set; }
    }
}
