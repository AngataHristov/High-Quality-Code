namespace TheatreSystem
{
    using System;

    public class Performance : IComparable<Performance>
    {
        private string theatreName;
        private string performanceTitle;
        private DateTime startDateTime;
        private TimeSpan duration;
        private decimal price;

        public Performance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            this.TheatreName = theatreName;
            this.PerformanceTitle = performanceTitle;
            this.StartDateTime = startDateTime;
            this.Duration = duration;
            this.Price = price;
        }

        public string TheatreName
        {
            get
            {
                return this.theatreName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null");
                }

                this.theatreName = value;
            }
        }

        public string PerformanceTitle
        {
            get
            {
                return this.performanceTitle;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("PerformanceTitle cannot be null");
                }

                this.performanceTitle = value;
            }
        }

        public DateTime StartDateTime
        {
            get
            {
                return this.startDateTime;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Time cannot be null");
                }

                this.startDateTime = value;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return this.duration;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Duration cannot be null");
                }

                this.duration = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }

                this.price = value;
            }
        }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            int result = this.StartDateTime.CompareTo(otherPerformance.StartDateTime);
            return result;
        }
    }
}
