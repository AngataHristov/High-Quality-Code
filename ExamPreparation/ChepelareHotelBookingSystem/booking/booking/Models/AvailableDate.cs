﻿namespace HotelBookingSystem.Models
{
    using System;
    using Utilities;

    public class AvailableDate
    {
        private DateTime endDate;

        public AvailableDate(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }

            private set
            {
                if (value < this.StartDate)
                {
                    throw new ArgumentException(Constants.InvalidDateRangeMsg);
                }

                this.endDate = value;
            }
        }
    }
}