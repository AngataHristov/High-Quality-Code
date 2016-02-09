
namespace TravelAgency.Core
{
    using System;
    using System.Globalization;
    using Interfaces;

    public class CommandManager : ICommandManager
    {
        private ITicketCatalog ticketCatalog;

        public CommandManager(ITicketCatalog ticketCatalog)
        {
            this.ticketCatalog = ticketCatalog;
        }

        public string ExecuteCommand(string line)
        {
            int firstSpaceIndex = line.IndexOf(' ');

            if (firstSpaceIndex == -1)
            {
                return Constants.InvalidCommand;
            }

            string commandType = line.Substring(0, firstSpaceIndex);
            string allParameters = line.Substring(firstSpaceIndex + 1);
            string[] parameters = allParameters.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            string command = null;
            switch (commandType)
            {
                case "AddAir":
                    command = this.ExecuteAddAirTicket(parameters);
                    break;
                case "DeleteAir":
                    command = this.ExecuteDeleteAirTicket(parameters);
                    break;
                case "AddTrain":
                    command = this.ExecuteAddTrainTicket(parameters);
                    break;
                case "DeleteTrain":
                    command = this.ExecuteDeleteTrainTicket(parameters);
                    break;
                case "AddBus":
                    command = this.ExecuteAddBusTicket(parameters);
                    break;
                case "DeleteBus":
                    command = this.ExecuteDeleteBusTicket(parameters);
                    break;
                case "FindTickets":
                    command = this.ExecuteFindTickets(parameters);
                    break;
                case "FindTicketsInInterval":
                    command = this.ExecutefindTicketsInInterval(parameters);
                    break;
            }

            return command;
        }

        private string ExecuteAddAirTicket(string[] parameters)
        {
            string flightNumber = parameters[0];
            string from = parameters[1];
            string to = parameters[2];
            string airline = parameters[3];
            DateTime dateTime = this.ParseDateTime(parameters[4]);
            decimal price = decimal.Parse(parameters[5]);
            string commandResult = this.ticketCatalog.AddAirTicket(flightNumber, from, to, airline, dateTime, price);

            return commandResult;
        }

        private string ExecuteDeleteAirTicket(string[] parameters)
        {
            string flightNumber = parameters[0];
            string commandResult = this.ticketCatalog.DeleteAirTicket(flightNumber);

            return commandResult;
        }

        private string ExecuteAddTrainTicket(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            DateTime dateTime = this.ParseDateTime(parameters[2]);
            decimal price = decimal.Parse(parameters[3]);
            decimal studentPrice = decimal.Parse(parameters[3]);
            string commandResult = this.ticketCatalog.AddTrainTicket(from, to, dateTime, price, studentPrice);

            return commandResult;
        }

        private string ExecuteDeleteTrainTicket(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            DateTime dateTime = this.ParseDateTime(parameters[2]);
            string commandResult = this.ticketCatalog.DeleteTrainTicket(from, to, dateTime);

            return commandResult;
        }

        private string ExecuteAddBusTicket(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            string travelCompany = parameters[2];
            DateTime dateTime = this.ParseDateTime(parameters[3]);
            decimal price = decimal.Parse(parameters[4]);
            string commandResult = this.ticketCatalog.AddBusTicket(from, to, travelCompany, dateTime, price);

            return commandResult;
        }

        private string ExecuteDeleteBusTicket(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            string travelCompany = parameters[2];
            DateTime dateTime = this.ParseDateTime(parameters[3]);
            string commandResult = this.ticketCatalog.DeleteBusTicket(from, to, travelCompany, dateTime);

            return commandResult;
        }

        private string ExecutefindTicketsInInterval(string[] parameters)
        {
            DateTime startDateTime = this.ParseDateTime(parameters[0]);
            DateTime endDateTime = this.ParseDateTime(parameters[0]);
            string commandResult = this.ticketCatalog.FindTicketsInInterval(startDateTime, endDateTime);

            return commandResult;
        }

        private string ExecuteFindTickets(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            string commandResult = this.ticketCatalog.FindTickets(from, to);

            return commandResult;
        }

        private DateTime ParseDateTime(string dateTime)
        {
            DateTime result = DateTime.ParseExact(dateTime, Constants.DateTimeFormat, CultureInfo.InvariantCulture);
            return result;
        }
    }
}
