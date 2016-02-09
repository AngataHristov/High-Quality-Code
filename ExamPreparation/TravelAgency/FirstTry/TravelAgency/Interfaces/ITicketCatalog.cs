namespace TravelAgency.Interfaces
{
    using System;
    using Enumerations;

    /// <summary>
    /// Defines a catalog, holding tickets
    /// and a set of commands about them
    /// </summary>
    public interface ITicketCatalog
    {
        /// <summary>
        /// Add an air ticket to the catalog by given flight number, departure
        /// and arrival airports(from, to), airline, departure date and time and price
        /// </summary>
        /// <param name="flightNumber">The number of flight</param>
        /// <param name="from">The start destination</param>
        /// <param name="to">The end destination</param>
        /// <param name="airline">The name of airline company</param>
        /// <param name="dateTime">The departure date and time for flight</param>
        /// <param name="price">The price of the ticket</param>
        /// <returns>A message "Ticket added" in case of success or "Dublicate ticket" if such
        ///  flight already exist.</returns>
        string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

        string DeleteAirTicket(string flightNumber);

        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

        string DeleteTrainTicket(string from, string to, DateTime dateTime);

        string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);

        /// <summary>
        /// Delete a bus ticket from the catalog by given departure town, arrival town,
        /// travel company and departure date and time
        /// </summary>
        /// <param name="from">The start destination</param>
        /// <param name="to">The end destination</param>
        /// <param name="travelCompany">The name of travel company</param>
        /// <param name="dateTime">The departure date and time for the bus</param>
        /// <returns>A message "Ticket deleted" in case of success or "Ticket does not exist"
        ///  if the ticket cannot be found in the catalog.</returns>
        string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

        /// <summary>
        /// Finds all tickets from the catalog by given departure town/airport (from) and arrival town/airport(to).
        /// </summary>
        /// <param name="from">The start destination</param>
        /// <param name="to">The end destination</param>
        /// <returns>All maching tickets on a single line, separateby spaces, in format
        /// [date and time; type; price], ordered by date and time (as first criteria, ascending),
        /// then by type (as second criteria, ascending) and then by price (as third criteria, ascending).
        /// If no tickets are found by the specified criteria, returns "Not found".</returns>
        string FindTickets(string from, string to);

        /// <summary>
        /// Finds all tickets from the catalog by given departure time interval.
        /// </summary>
        /// <param name="startDateTime">The start date and time </param>
        /// <param name="endDateTime">The end date and time </param>
        /// <returns>All maching tickets on a single line, separate by spaces, in format
        /// [date and time; type; price], ordered by date and time (as first criteria, ascending),
        /// then by type (as second criteria, ascending) and then by price (as third criteria, ascending).
        /// If no tickets are found by the specified criteria, returns "Not found".</returns>
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType type);
    }
}