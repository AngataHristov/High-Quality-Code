namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Utilities;

    public class Room : IDbEntity
    {
        private int places;
        private decimal pricePerDay;

        public Room(int places, decimal pricePerDay)
        {
            this.Places = places;
            this.PricePerDay = pricePerDay;
            this.Bookings = new HashSet<Booking>();
            this.AvailableDates = new HashSet<AvailableDate>();
        }

        public ICollection<AvailableDate> AvailableDates { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }

        public int Id { get; set; }

        public int Places
        {
            get
            {
                return this.places;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Constants.InvalidPlacesMsg, Constants.MinimumPlacesMsg));
                }

                this.places = value;
            }
        }

        public decimal PricePerDay
        {
            get
            {
                return this.pricePerDay;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Constants.PricePerDayMsg, Constants.MinimumPriceMsg));
                }

                this.pricePerDay = value;
            }
        }
    }
}