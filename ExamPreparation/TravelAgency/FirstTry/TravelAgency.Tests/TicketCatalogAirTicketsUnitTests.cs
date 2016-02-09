
namespace TravelAgency.Tests
{
    using System;
    using Enumerations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Interfaces;

    [TestClass]
    public class TicketCatalogAirTicketsUnitTests
    {
        [TestMethod]
        public void TestAddAirTicketReturnsTicketAdded()
        {
            ITicketCatalog catalog = new TicketsCatalog();

            string result = catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna",
                airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            Assert.AreEqual("Ticket added", result);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestAddAirTicketDublicates()
        {
            ITicketCatalog catalog = new TicketsCatalog();

            catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            string cmdResult = catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "London", airline: "Wizz Air", dateTime: new DateTime(2015, 1, 22, 06, 15, 00), price: 730.55M);

            Assert.AreEqual("Dublicated ticket", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketReturnsTicketDeleted()
        {
            ITicketCatalog catalog = new TicketsCatalog();

            catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            string result = catalog.DeleteAirTicket(flightNumber: "FX215");

            Assert.AreEqual("Ticket deleted", result);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketReturnsTicketDoesNotExist()
        {
            ITicketCatalog catalog = new TicketsCatalog();

            catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            string cmdResult = catalog.DeleteAirTicket(flightNumber: "FX217");

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteDeletedAirTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketsCatalog();

            catalog.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);
            catalog.DeleteAirTicket(flightNumber: "FX215");

            string cmdResult = catalog.DeleteAirTicket(flightNumber: "FX215");

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
        }
    }
}
