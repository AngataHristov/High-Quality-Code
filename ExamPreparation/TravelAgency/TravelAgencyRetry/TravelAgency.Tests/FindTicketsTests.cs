
namespace TravelAgency.Tests
{
    using System;
    using Enumerations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Interfaces;

    [TestClass]
    public class FindTicketsTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void TestInitialize()
        {
            this.catalog = new TicketCatalog();
        }

        [TestMethod]
        public void FindTicketsReturnsTickets()
        {
            this.catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            this.catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV453");

            this.catalog.AddBusTicket(from: "Varna", to: "Sofia", dateTime: new DateTime(2015, 1, 30, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");
            this.catalog.AddTrainTicket(from: "SOFIA", to: "VARNA", dateTime: new DateTime(2015, 1, 23, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            this.catalog.AddAirTicket(from: "sofia", to: "varna", dateTime: new DateTime(2015, 1, 24, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV7023");
            this.catalog.AddBusTicket(from: "Varna2", to: "Sofia2", dateTime: new DateTime(2015, 1, 25, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");

            string cmdResult = catalog.FindTickets(from: "Sofia", to: "Varna");

            Assert.AreEqual("[29.01.2015 07:40; air; 24.00] [30.01.2015 12:55; train; 26.00]", cmdResult);
        }

        [TestMethod]
        public void FindTicketsReturnsNotFound()
        {
            this.catalog.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            this.catalog.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV453");

            this.catalog.AddBusTicket(from: "Varna", to: "Sofia", dateTime: new DateTime(2015, 1, 30, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");
            this.catalog.AddTrainTicket(from: "SOFIA", to: "VARNA", dateTime: new DateTime(2015, 1, 23, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            this.catalog.AddAirTicket(from: "sofia", to: "varna", dateTime: new DateTime(2015, 1, 24, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV7023");
            this.catalog.AddBusTicket(from: "Varna2", to: "Sofia2", dateTime: new DateTime(2015, 1, 25, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");

            string cmdResult = catalog.FindTickets(from: "Db", to: "Varna");

            Assert.AreEqual("Not found", cmdResult);

        }
    }
}
