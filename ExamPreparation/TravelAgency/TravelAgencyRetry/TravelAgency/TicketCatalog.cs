
namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    using Core;
    using Enumerations;
    using Interfaces;
    using Tickets;

    public class TicketCatalog : ITicketCatalog
    {
        private Dictionary<string, Ticket> ticketsByUniqueKey;
        private MultiDictionary<string, Ticket> ticketsFromTo;
        private OrderedMultiDictionary<DateTime, Ticket> tickertByDateTime;
        private Dictionary<TicketType, int> ticketsCountByType;

        public TicketCatalog()
        {
            this.ticketsByUniqueKey = new Dictionary<string, Ticket>();
            this.ticketsFromTo = new MultiDictionary<string, Ticket>(true);
            this.tickertByDateTime = new OrderedMultiDictionary<DateTime, Ticket>(true);
            this.ticketsCountByType = new Dictionary<TicketType, int>();

            this.ticketsCountByType[TicketType.Bus] = 0;
            this.ticketsCountByType[TicketType.Air] = 0;
            this.ticketsCountByType[TicketType.Train] = 0;
        }

        public string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price)
        {
            AirTicket ticket = new AirTicket(flightNumber, from, to, airline, dateTime, price);

            string result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            AirTicket ticket = new AirTicket(flightNumber);

            string result = this.DeleteTicketByUniqueKey(ticket.UniqueKey);

            return result;
        }

        public string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateTime, price, studentPrice);

            string result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateTime)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateTime);

            string result = this.DeleteTicketByUniqueKey(ticket.UniqueKey);

            return result;
        }

        public string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price)
        {
            BusTicket ticket = new BusTicket(from, to, travelCompany, dateTime, price);

            string result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime)
        {
            BusTicket ticket = new BusTicket(from, to, travelCompany, dateTime);

            string result = this.DeleteTicketByUniqueKey(ticket.UniqueKey);

            return result;
        }

        public string FindTickets(string from, string to)
        {
            string fromToKey = this.CreateFromToKey(from, to);
            if (this.ticketsFromTo.ContainsKey(fromToKey))
            {
                var ticketsFound = this.ticketsFromTo[fromToKey];
                string ticketsAsString = this.FormatTicketForPRinting(ticketsFound);

                return ticketsAsString;
            }

            return Constants.NotFound;
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.tickertByDateTime.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = this.FormatTicketForPRinting(ticketsFound);

                return ticketsAsString;
            }

            return Constants.NotFound;
        }

        public int GetTicketsCount(TicketType type)
        {
            int result = this.ticketsCountByType[type];

            return result;
        }

        private string AddTicket(Ticket ticket)
        {
            string key = ticket.UniqueKey;

            if (this.ticketsByUniqueKey.ContainsKey(key))
            {
                return Constants.DuplicatedTicket;
            }

            this.ticketsByUniqueKey.Add(key, ticket);
            string fromToKey = this.CreateFromToKey(ticket.From, ticket.To);
            this.ticketsFromTo.Add(fromToKey, ticket);
            this.tickertByDateTime.Add(ticket.DateAndTime, ticket);
            this.ticketsCountByType[ticket.Type]++;

            return Constants.TicketAdded;
        }

        private string DeleteTicketByUniqueKey(string UniqueKey)
        {

            if (this.ticketsByUniqueKey.ContainsKey(UniqueKey))
            {
                Ticket ticket = this.ticketsByUniqueKey[UniqueKey];
                this.ticketsByUniqueKey.Remove(UniqueKey);
                string fromToKey = this.CreateFromToKey(ticket.From, ticket.To);
                this.ticketsFromTo.Remove(fromToKey, ticket);
                this.tickertByDateTime.Remove(ticket.DateAndTime, ticket);
                this.ticketsCountByType[ticket.Type]--;

                return Constants.TicketDeleted;
            }

            return Constants.TicketDoesNotExist;
        }

        private string FormatTicketForPRinting(ICollection<Ticket> tickets)
        {
            string result = string.Join(" ", tickets.OrderBy(t => t));

            return result;
        }

        private string CreateFromToKey(string from, string to)
        {
            return string.Format("{0}; {1}", @from, to);
        }
    }
}
