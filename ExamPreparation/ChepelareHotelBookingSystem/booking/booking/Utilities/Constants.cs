namespace HotelBookingSystem.Utilities
{
    public static class Constants
    {
        public const string ControllerSuffixMsg = "Controller";
        public const string NamesapceSeparatorMsg = ".";
        public const string ViewsFolderMsg = "Views";
        public const string DateFormatMsg = "dd.MM.yyyy";

        public const string VenueWithIdNotExistMsg = "The venue with ID {0} does not exist.";
        public const string RoomWithIdNotExistMsg = "The room with ID {0} does not exist.";
        public const string InvalidDateRangeMsg = "The date range is invalid.";
        public const string InvalidRoomForPeriodMsg = "The room is not available to book in the period {0:dd.MM.yyyy} - {1:dd.MM.yyyy}.";

        public const string NotMatchPasswordMsg = "The provided passwords do not match.";
        public const string UserAlreadyExistMsg = "A user with username {0} already exists.";
        public const string UserNotExistMsg = "A user with username {0} does not exist.";
        public const string WrongPasswordMsg = "The provided password is wrong.";

        public const string AlreadyLoggedInUserMsg = "There is already a logged in user.";
        public const string UserNameCannotBeChangeMsg = "A user's username cannot be changed.";
        public const string NoLoggedInUserMsg = "There is no currently logged in user.";
        public const string NoRightsMsg = "The currently logged in user doesn't have sufficient rights to perform this operation.";
        public const string InvalidRouteMsg = "The provided route is invalid.";
        public const string InvalidTotalPriceMsg = "The total price must not be less than {0}.";
        public const string InvalidPlacesMsg = "The places must not be less than {0}.";
        public const string PricePerDayMsg = "The price per day must not be less than {0}.";

        public const string UserNameLengthMsg = "The username must be at least {0} symbols long.";
        public const string PasswordLengthMsg = "The password must be at least {0} symbols long.";
        public const string VenueNameLengthMsg = "The venue name must be at least {0} symbols long.";
        public const string VenueAddressLengthMsg = "The venue address must be at least {0} symbols long.";

        public const string SometingHappendMsg = "Something happened!!1";

        public const string RoomCreatedMsg = "The room with ID {0} has been created successfully.";
        public const string PeriodAddedToRoomMsg = "The period has been added to room with ID {0}.";
        public const string RoomBookedMsg = "Room booked from {0:dd.MM.yyyy} to {1:dd.MM.yyyy} for ${2:F2}.";
        public const string NoBookingForRoomMsg = "There are no bookings for this room.";
        public const string RegisteredUserMsg = "The user {0} has been registered and may login.";

        public const string UserLoggedInMsg = "The user {0} has logged in.";
        public const string UserLoggedOutMsg = "The user {0} has logged out.";
        public const string NotAnyBookingYetMsg = "You have not made any bookings yet.";
        public const string VenueCreatedMsg = "The venue {0} with ID {1} has been created successfully.";
        public const string NoVenuesToShowMsg = "There are currently no venues to show.";
        public const string NoRoomsAvailableMsg = "No rooms are currently available.";
        public const string AvaliableRoomForVenueMsg = "Available rooms for venue {0}:";
        public const string RoomNotCurrentlyAvaliableMsg = "This room is not currently available.";
        public const string TotalBookingPriceMsg = "Total booking price: ${0:F2}";

        public const int MinimumPriceMsg = 0;
        public const int MinimumPlacesMsg = 0;
        public const int MinimumUserNameLengthMsg = 5;
        public const int MinimumPasswordLengthMsg = 6;
        public const int MinimumVenueNameLengthMsg = 3;
        public const int MinimumVenueAddressLengthMsg = 3;
    }
}
