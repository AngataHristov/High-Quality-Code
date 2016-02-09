namespace HotelBookingSystem.Models
{
    using System;
    using Interfaces;
    using Utilities;

    public class Booking : IDbEntity
    {
        private DateTime endDate;
        private decimal totalPrice;

        public Booking(User client, DateTime startBookDate, DateTime endBookDate, decimal totalPrice, string comments)
        {
            this.StartBookDate = startBookDate;
            this.EndBookDate = endBookDate;
            this.TotalPrice = totalPrice;
            this.Comments = comments;
            this.Client = client;
        }

        public int Id { get; set; }

        public User Client { get; private set; }

        public string Comments { get; private set; }

        public DateTime StartBookDate { get; private set; }

        public DateTime EndBookDate
        {
            get
            {
                return this.endDate;
            }

            private set
            {
                if (value < this.StartBookDate)
                {
                    throw new ArgumentException(Constants.InvalidDateRangeMsg);
                }

                this.endDate = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return this.totalPrice;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Constants.InvalidTotalPriceMsg, Constants.MinimumPriceMsg));
                }

                this.totalPrice = value;
            }
        }
    }
}