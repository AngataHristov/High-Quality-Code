
namespace TravelAgency.Tickets
{
    using System;
    using Enumerations;

    public class BusTicket : Ticket
    {
        public BusTicket(string from, string to, string travelCompany, DateTime dateAndTime, decimal price = 0)
            : base(from, to, dateAndTime, price)
        {
            this.TravelCompany = travelCompany;
        }

        public string TravelCompany { get; set; }

        public override TicketType Type
        {
            get { return TicketType.Bus; }
        }

        public override string UniqueKey
        {
            get
            {
                return string.Format("{0};;{1};{2};{3};{4};", this.Type, this.From, this.To, this.TravelCompany, this.DateAndTime);
            }
        }
    }
}
