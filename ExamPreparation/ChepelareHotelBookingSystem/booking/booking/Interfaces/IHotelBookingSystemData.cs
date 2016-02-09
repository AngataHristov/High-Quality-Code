namespace HotelBookingSystem.Interfaces
{
    using Models;

    public interface IHotelBookingSystemData
    {
        IUserRepository UsersRepository { get; }

        IRepository<Venue> VenuesRepository { get; }

        IRepository<Room> RoomsRepository { get; }

        IRepository<Booking> BookingRepository { get; }
    }
}
