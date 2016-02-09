
namespace TravelAgency.Tests
{
    using System;
    using Enumerations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Interfaces;

    [TestClass]
    public class TrainTicketTests
    {
        private ITicketCatalog catalog;

        [TestInitialize]
        public void TestInitialize()
        {
            this.catalog = new TicketCatalog();
        }

        [TestMethod]
        public void AddTrainTicketReturnsTicketAdded()
        {
            string result = this.catalog.AddTrainTicket("Varna", "Sofia", new DateTime(2015, 1, 27, 05, 22, 00), 26.54m, 12.22m);
            Assert.AreEqual("Ticket added", result);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Train));
        }


        [TestMethod]
        public void AddTrainTicketReturnsDublicate()
        {
            this.catalog.AddTrainTicket("Varna", "Sofia", new DateTime(2015, 1, 27, 05, 22, 00), 26.54m, 12.22m);

            string result = this.catalog.AddTrainTicket("Varna", "Sofia", new DateTime(2015, 1, 27, 05, 22, 00), 26.54m, 12.22m);

            Assert.AreEqual("Dublicated ticket", result);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void DeleteTrainTicketReturnsTicketDeleted()
        {
            this.catalog.AddTrainTicket("Varna", "Sofia", new DateTime(2015, 1, 27, 05, 22, 00), 26.54m, 12.22m);
            string result = this.catalog.DeleteTrainTicket("Varna", "Sofia", new DateTime(2015, 1, 27, 05, 22, 00));

            Assert.AreEqual("Ticket deleted", result);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void DeleteTrainTicketReturnsTicketDoesNotExist()
        {
            this.catalog.AddTrainTicket("Varna", "Sofia", new DateTime(2015, 1, 27, 05, 22, 00), 26.54m, 12.22m);
            string result = this.catalog.DeleteTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 27, 05, 22, 00));

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(1, this.catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void DeleteDeletedTrainTicketReturnsTicketDoesNotExist()
        {
            this.catalog.AddTrainTicket("Varna", "Sofia", new DateTime(2015, 1, 27, 05, 22, 00), 26.54m, 12.22m);
            this.catalog.DeleteTrainTicket("Varna", "Sofia", new DateTime(2015, 1, 27, 05, 22, 00));

            string result = this.catalog.DeleteTrainTicket("Varna", "Sofia", new DateTime(2015, 1, 27, 05, 22, 00));

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(0, this.catalog.GetTicketsCount(TicketType.Train));
        }
    }
}
