
namespace TravelAgency.Tests
{
    using System;
    using Enumerations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Interfaces;

    [TestClass]
    public class BusTicketTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void TestInitialize()
        {
            this.catalog = new TicketCatalog();
        }

        [TestMethod]
        public void AddBusTicketReturnsTicketAdded()
        {
            string result = this.catalog.AddBusTicket("Sofia", "Varna", "Biomet", new DateTime(2015, 1, 15, 06, 15, 00), 15m);

            Assert.AreEqual("Ticket added", result);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Bus));
        }


        [TestMethod]
        public void AddBusTicketReturnsDublicate()
        {
            this.catalog.AddBusTicket("Sofia", "Varna", "Biomet", new DateTime(2015, 1, 15, 06, 15, 00), 15m);

            string result = this.catalog.AddBusTicket("Sofia", "Varna", "Biomet", new DateTime(2015, 1, 15, 06, 15, 00), 15m);

            Assert.AreEqual("Dublicated ticket", result);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void DeleteBusTicketReturnsTicketDeleted()
        {
            this.catalog.AddBusTicket("Sofia", "Varna", "Biomet", new DateTime(2015, 1, 15, 06, 15, 00), 15m);
            string result = this.catalog.DeleteBusTicket("Sofia", "Varna", "Biomet", new DateTime(2015, 1, 15, 06, 15, 00));

            Assert.AreEqual("Ticket deleted", result);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void DeleteBusTicketReturnsTicketDoesNotExist()
        {
            this.catalog.AddBusTicket("Sofia", "Varna", "Biomet", new DateTime(2015, 1, 15, 06, 15, 00), 15m);
            string result = this.catalog.DeleteBusTicket("Varna", "Varna", "Biomet", new DateTime(2015, 1, 15, 06, 15, 00));

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void DeleteDeletedBusTicketReturnsTicketDoesNotExist()
        {
            this.catalog.AddBusTicket("Sofia", "Varna", "Biomet", new DateTime(2015, 1, 15, 06, 15, 00), 15m);
            this.catalog.DeleteBusTicket("Sofia", "Varna", "Biomet", new DateTime(2015, 1, 15, 06, 15, 00));

            string result = this.catalog.DeleteBusTicket("Sofia", "Varna", "Biomet", new DateTime(2015, 1, 15, 06, 15, 00));

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Bus));
        }
    }
}
