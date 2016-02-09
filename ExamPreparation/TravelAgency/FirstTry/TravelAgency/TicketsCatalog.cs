
namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    using Interfaces;
    using Enumerations;
    using Tickets;

    // TODO: document this interface
    // Do not modify the interface members
    // Moving the interface to separate namespace is allowed
    // Adding XML documentation is allowed

    public class TicketsCatalog : ITicketCatalog
    {
        private IDictionary<string, Ticket> ticketsByUniqueKey =
            new Dictionary<string, Ticket>();

        private MultiDictionary<string, Ticket> ticketsFromTo =
            new MultiDictionary<string, Ticket>(true);

        private OrderedMultiDictionary<DateTime, Ticket> ticketsByDate =
             new OrderedMultiDictionary<DateTime, Ticket>(true);

        private IDictionary<TicketType, int> ticketCountByType =
            new Dictionary<TicketType, int>();

        public TicketsCatalog()
        {
            this.ticketCountByType[TicketType.Air] = 0;
            this.ticketCountByType[TicketType.Bus] = 0;
            this.ticketCountByType[TicketType.Train] = 0;
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
            string fromToKey = CreateFromToKey(from, to);

            if (this.ticketsFromTo.ContainsKey(fromToKey))
            {
                var ticketsFount = this.ticketsFromTo[fromToKey];
                string ticketAsString = FormatTicketForPrinting(ticketsFount);
                return ticketAsString;
            }

            return Constants.NotFound;
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.ticketsByDate.Range(startDateTime, true, endDateTime, true).Values;

            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = FormatTicketForPrinting(ticketsFound);

                return ticketsAsString;
            }

            return Constants.NotFound;
        }

        private string AddTicket(Ticket ticket)
        {
            string key = ticket.UniqueKey;

            if (this.ticketsByUniqueKey.ContainsKey(key))
            {
                return Constants.DuplicatedTicket;
            }

            this.ticketsByUniqueKey.Add(key, ticket);
            string fromToKey = CreateFromToKey(ticket.From, ticket.To);
            this.ticketsFromTo.Add(fromToKey, ticket);
            this.ticketsByDate.Add(ticket.DateTime, ticket);
            this.ticketCountByType[ticket.Type]++;

            return Constants.TicketAdded;
        }

        private string DeleteTicketByUniqueKey(string uniqueKey)
        {
            if (this.ticketsByUniqueKey.ContainsKey(uniqueKey))
            {
                Ticket ticket = this.ticketsByUniqueKey[uniqueKey];
                this.ticketsByUniqueKey.Remove(uniqueKey);
                string fromToKey = CreateFromToKey(ticket.From, ticket.To);
                this.ticketsFromTo.Remove(fromToKey, ticket);
                this.ticketsByDate.Remove(ticket.DateTime, ticket);
                this.ticketCountByType[ticket.Type]--;

                return Constants.TicketDeleted;
            }

            return Constants.TicketDoesNotExist;
        }

        private static string CreateFromToKey(string from, string to)
        {
            return from + "; " + to;
        }

        private static string FormatTicketForPrinting(IEnumerable<Ticket> tickets)
        {
            string ticketsStr = string.Join(" ", tickets.OrderBy(t => t));
            return ticketsStr;
        }

        public int GetTicketsCount(TicketType type)
        {
            return this.ticketCountByType[type];
        }
    }
}