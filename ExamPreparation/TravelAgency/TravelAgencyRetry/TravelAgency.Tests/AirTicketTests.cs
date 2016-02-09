

namespace TravelAgency.Tests
{
    using System;
    using Enumerations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Interfaces;

    [TestClass]
    public class AirTicketTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void TestInitialize()
        {
            this.catalog = new TicketCatalog();
        }

        [TestMethod]
        public void AddAirTicketReturnsTicketAdded()
        {
            string result = this.catalog.AddAirTicket("FX215", "Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 00), 200m);

            Assert.AreEqual("Ticket added", result);
            Assert.AreEqual(1,this.catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void AddAirTicketReturnsDublicate()
        {
            this.catalog.AddAirTicket("FX215", "Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 00), 200m);

            string result = this.catalog.AddAirTicket("FX215", "Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 00), 200m);

            Assert.AreEqual("Dublicated ticket", result);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void DeleteAirTicketReturnsTicketDeleted()
        {
            this.catalog.AddAirTicket("FX215", "Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 00), 200m);
            string result = this.catalog.DeleteAirTicket("FX215");

            Assert.AreEqual("Ticket deleted",result);
            Assert.AreEqual(0,this.catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void DeleteAirTicketReturnsTicketDoesNotExist()
        {
            this.catalog.AddAirTicket("FX215", "Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 00), 200m);
            string result = this.catalog.DeleteAirTicket("FX217");

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void DeleteDeletedAirTicketReturnsTicketDoesNotExist()
        {
            this.catalog.AddAirTicket("FX215", "Sofia", "Athens", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 00), 200m);
            this.catalog.DeleteAirTicket("FX215");

            string result = this.catalog.DeleteAirTicket("FX215");

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Air));
        }
    }
}
