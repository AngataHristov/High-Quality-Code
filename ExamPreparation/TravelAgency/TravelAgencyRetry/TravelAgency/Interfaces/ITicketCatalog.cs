namespace TravelAgency.Interfaces
{
    using System;
    using Enumerations;

    /// <summary>
    /// Defines a traveling catalog, holding diferent type of tickets
    /// and a set of commands about them
    /// </summary>
    public interface ITicketCatalog
    {
        /// <summary>
        /// Add an air ticket to the catalog by given information: flightnumber,
        /// departure and arrival destination(from, to), airline, departure date and time and price.
        /// </summary>
        /// <param name="flightNumber">The number of flight</param>
        /// <param name="from">The departure destination</param>
        /// <param name="to">The arrival destination</param>
        /// <param name="airline">The name of airline company</param>
        /// <param name="dateTime">The departure date and time</param>
        /// <param name="price">The price of the ticker</param>
        /// <returns>A message "Ticket added" in case of success or 
        /// "Duplicated ticket" if such flight already exist </returns>
        string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

        string DeleteAirTicket(string flightNumber);

        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

        string DeleteTrainTicket(string from, string to, DateTime dateTime);

        string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);

        /// <summary>
        /// Delete a bus ticket from the catalog by given information: departure and arrival destination(from, to),
        /// travel company and departure date and time.
        /// </summary>
        /// <param name="from">The departure destination</param>
        /// <param name="to">The arrival destination</param>
        /// <param name="travelCompany">The name of bus company</param>
        /// <param name="dateTime">The departure date and time</param>
        /// <returns>a message "Ticket deleted" in case of success or
        /// "Ticket does not exist" if the ticket cannot be found int he catalog</returns>
        string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

        /// <summary>
        /// Finds all tickets from the catalog by given information: departure and arrival destination(from, to).
        /// </summary>
        /// <param name="from">The departure destination</param>
        /// <param name="to">The arrival destination</param>
        /// <returns>All maching tickets ot a single line, separate by spaces, in format [date and time; type; price] and sorted.
        /// If no tickets were found by the given criteria, returns "Not found".</returns>
        string FindTickets(string from, string to);

        /// <summary>
        /// Finds all tickets from the catalog by given departure time interval
        /// </summary>
        /// <param name="startDateTime">The start date and time</param>
        /// <param name="endDateTime">The end date and time</param>
        /// <returns>All maching tickets ot a single line, separate by spaces, in format [date and time; type; price] and sorted.
        /// If no tickets were found by the given criteria, returns "Not found".</returns>
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType type);
    }
}


