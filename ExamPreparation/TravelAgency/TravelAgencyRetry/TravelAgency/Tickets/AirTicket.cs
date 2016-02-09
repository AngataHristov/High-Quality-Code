
namespace TravelAgency.Tickets
{
    using System;
    using Enumerations;

    public class AirTicket : Ticket
    {
        public AirTicket(string flightNumber, string from, string to, string airline, DateTime dateAndTime, decimal price)
            : base(from, to, dateAndTime, price)
        {
            this.FlightNumber = flightNumber;
            this.Airline = airline;
        }

        public AirTicket(string flightNumber)
            : this(null, null, null, null, default(DateTime), 0)
        {
            this.FlightNumber = flightNumber;
        }

        public string Airline { get; set; }

        public string FlightNumber { get; set; }

        public override TicketType Type
        {
            get { return TicketType.Air; }
        }

        public override string UniqueKey
        {
            get { return string.Format("{0};;{1};", this.Type, this.FlightNumber); }
        }
    }
}
