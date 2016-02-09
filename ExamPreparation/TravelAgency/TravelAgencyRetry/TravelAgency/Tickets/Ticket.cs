
namespace TravelAgency.Tickets
{
    using System;
    using Core;
    using Enumerations;

    public abstract class Ticket : IComparable<Ticket>
    {
        public Ticket(string from, string to, DateTime dateAndTime, decimal price)
        {
            this.From = from;
            this.To = to;
            this.DateAndTime = dateAndTime;
            this.Price = price;
        }

        public abstract TicketType Type { get; }

        public string From { get; private set; }

        public string To { get; private set; }

        public DateTime DateAndTime { get; private set; }

        public decimal Price { get; private set; }

        public abstract string UniqueKey { get; }

        public override string ToString()
        {
            string result = string.Format("[{0}; {1}; {2}]", this.DateAndTime.ToString(Constants.DateTimeFormat),
                            this.Type.ToString().ToLower(), String.Format("{0:f2}", this.Price));

            return result;
        }

        public int CompareTo(Ticket otherTicket)
        {
            int compareResult = this.DateAndTime.CompareTo(otherTicket.DateAndTime);
            if (compareResult == 0)
            {
                compareResult = ((int)this.Type).CompareTo((int)otherTicket.Type);
            }
            if (compareResult == 0)
            {
                compareResult = this.Price.CompareTo(otherTicket.Price);
            }
            return compareResult;
        }
    }
}
