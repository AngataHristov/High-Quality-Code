
namespace TravelAgency.Tickets
{
    using System;
    using Enumerations;

    public class TrainTicket : Ticket
    {
        public TrainTicket(string from, string to, DateTime dateAndTime, decimal price, decimal studentPrice)
            : base(from, to, dateAndTime, price)
        {
            this.StudentPrice = studentPrice;
        }

        public TrainTicket(string from, string to, DateTime dateAndTime)
            : base(from, to, dateAndTime, 0)
        {
        }

        public decimal StudentPrice { get; set; }

        public override TicketType Type
        {
            get { return TicketType.Train; }
        }

        public override string UniqueKey
        {
            get
            {
                return string.Format("{0};;{1};{2};{3};", this.Type, this.From, this.To, this.DateAndTime);
            }
        }
    }
}
