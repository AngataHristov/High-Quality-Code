namespace HotelBookingSystem.Tests
{
    using System;
    using Controllers;
    using Data;
    using Enums;
    using Exceptions;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Utilities;

    [TestClass]
    public class ControllerTests
    {
        private IRepository<Venue> repository;
        private IHotelBookingSystemData data;

        [TestInitialize]
        public void Initialize()
        {
            this.repository = new Repository<Venue>();
            this.data = new HotelBookingSystemData();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Authorize_NoLoggedUser_ShouldThrow()
        {
            var controller = new VenuesController(this.data, null);

            controller.Details(1);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void Authorize_NoSufficientRights_ShouldThrow()
        {
            var user = new User("admin", "123456", Roles.User);
            var controller = new VenuesController(this.data, user);

            controller.Add("nqma ime", "nqma adres", "nqma opisanie");
        }

        [TestMethod]
        public void Authorize_ValidUser_ShouldPass()
        {
            var user = new User("admin", "123456", Roles.VenueAdmin);
            var controller = new VenuesController(this.data, user);

            controller.Add("nqma ime", "nqma adres", "nqma opisanie");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Loguot_NoLoggedUser_ShouldThrow()
        {
            var controller = new UsersController(this.data, null);

            controller.Logout();
        }

        [TestMethod]
        public void Loguot_LoggedUser_ShouldThrow()
        {
            var user = new User("admin", "123456", Roles.VenueAdmin);
            var controller = new UsersController(this.data, user);

            controller.Logout();

            Assert.IsNull(controller.CurrentUser);
        }

        [TestMethod]
        public void AllVenues_NoVenues_CorrectReturnString()
        {
            var user = new User("admin", "123456", Roles.VenueAdmin);
            var controller = new VenuesController(this.data, user);

            string expectedResult = Constants.NoVenuesToShowMsg;
            var result = controller.All().Display();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AllVenues_WithVenues_CorrectReturnString()
        {
            var user = new User("admin", "123456", Roles.VenueAdmin);
            var controller = new VenuesController(this.data, user);

            controller.Add("New venue", "Sofia", "nqma opisanie");

            var expectedResult = "*[1] New venue, located at Sofia" + Environment.NewLine + "Free rooms: 0";
            var result = controller.All().Display();

            Assert.AreEqual(expectedResult, result);
        }
    }
}
