namespace BuhtigIssueTracker.Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using Core.Trackers;
    using Data;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;
    using Utilities;

    [TestClass]
    public class UserTrackerTests
    {
        private IDatabase database;
        private IUserTracker userTracker;
        //private IList<IUser> mockedUsers;

        [TestInitialize]
        public void Initialize()
        {
            // this.mockedUsers = new List<IUser>();

            // var mockedData = new Mock<IDatabase>();
            //mockedData.Setup(d => d.Users)
            //    .Returns(mockedUsers);
            // mockedData.Setup(d => d.Users.Add(It.IsAny<string>(), It.IsAny<IUser>()))
            //     .Callback<string, IUser>((s, u) => mockedUsers.Add(u));

            //this.database = mockedData.Object;

            this.database = new Database();
            this.userTracker = new UserTracker(this.database);
        }

        [TestMethod]
        public void TestRegisterUser_NonExistedUser_ShouldReturnCorrectMesage()
        {
            string result = this.userTracker.RegisterUser("peshko", "123456", "123456");

            string expectedMessage = "User peshko registered successfully";

            Assert.AreEqual(expectedMessage, result);
        }

        [TestMethod]
        public void TestRegisterUser_WithCurrentlyLoggedInUser_ShouldReturnCorrectMesage()
        {
            this.userTracker.RegisterUser("peshko", "123456", "123456");
            this.userTracker.LoginUser("peshko", "123456");

            string result = this.userTracker.RegisterUser("gosho", "3455667", "3455667");
            string expectedMessage = Constants.AlreadyLogedinUserMsg;

            Assert.AreEqual(expectedMessage, result);
        }

        [TestMethod]
        public void TestRegisterUser_NonPassedPasswor_ShouldReturnCorrectMesage()
        {
            string result = this.userTracker.RegisterUser("gosho", "3455667", "4564332");
            string expectedMessage = Constants.ProvidedPasswordNotMatchMsg;

            Assert.AreEqual(expectedMessage, result);
        }

        [TestMethod]
        public void TestRegisterUser_WithSameName_ShouldReturnCorrectMesage()
        {
            this.userTracker.RegisterUser("peshko", "123456", "123456");
            string result = this.userTracker.RegisterUser("peshko", "3455667", "3455667");

            string expectedMessage = "A user with username peshko already exists";

            Assert.AreEqual(expectedMessage, result);
        }

        [TestMethod]
        public void TestRegisterUser_NonExistedUser_ShouldIncreaseCount()
        {
            this.userTracker.RegisterUser("peshko", "123456", "123456");

            int expectedCount = 1;
            int count = this.database.Users.Count;
            // int result = this.mockedUsers.Count;
            Assert.AreEqual(expectedCount, count);
        }


    }
}
