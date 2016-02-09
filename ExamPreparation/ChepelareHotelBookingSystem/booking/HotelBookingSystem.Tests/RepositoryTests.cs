namespace HotelBookingSystem.Tests
{
    using Data;
    using Enums;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class RepositoryTests
    {
        private IRepository<Venue> repository;

        [TestInitialize]
        public void Initialize()
        {
            this.repository = new Repository<Venue>();
        }

        [TestMethod]
        public void GetMethod_EmptyRepository_ShouldResurnNull()
        {
            var result = this.repository.Get(6);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetMethod_ItemPresent_ShouldResurnItemName()
        {
            var user = new User("admin", "123456", Roles.VenueAdmin);

            this.repository.Add(new Venue("Venue1", "Sofia 14", "Nqma", user));
            this.repository.Add(new Venue("Venue2", "Sofia 14", "Nqma", user));
            this.repository.Add(new Venue("Venue3", "Sofia 14", "Nqma", user));

            var result = this.repository.Get(2);

            Assert.AreEqual("Venue2", result.Name);
        }

        [TestMethod]
        public void GetMethod_ItemPresent_ShouldResurnItemAddress()
        {
            var user = new User("admin", "123456", Roles.VenueAdmin);

            this.repository.Add(new Venue("Venue1", "Sofia 13", "Nqma", user));
            this.repository.Add(new Venue("Venue2", "Sofia 14", "Nqma", user));
            this.repository.Add(new Venue("Venue3", "Sofia 15", "Nqma", user));

            var result = this.repository.Get(2);

            Assert.AreEqual("Sofia 14", result.Address);
        }

        [TestMethod]
        public void GetMethod_ItemPresent_ShouldResurnItemDescription()
        {
            var user = new User("admin", "123456", Roles.VenueAdmin);

            this.repository.Add(new Venue("Venue1", "Sofia 13", "Nqma", user));
            this.repository.Add(new Venue("Venue2", "Sofia 14", "Ima", user));
            this.repository.Add(new Venue("Venue3", "Sofia 15", "Nqma", user));

            var result = this.repository.Get(2);

            Assert.AreEqual("Ima", result.Description);
        }

        [TestMethod]
        public void GetMethod_ItemPresent_ShouldResurnItemId()
        {
            var user = new User("admin", "123456", Roles.VenueAdmin);

            this.repository.Add(new Venue("Venue1", "Sofia 13", "Nqma", user));
            this.repository.Add(new Venue("Venue2", "Sofia 14", "Ima", user));
            this.repository.Add(new Venue("Venue3", "Sofia 15", "Nqma", user));

            var result = this.repository.Get(2);

            Assert.AreEqual(2, result.Id);
        }
    }
}
