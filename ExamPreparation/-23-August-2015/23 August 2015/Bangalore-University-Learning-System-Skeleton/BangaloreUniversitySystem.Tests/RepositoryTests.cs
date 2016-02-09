

namespace BangaloreUniversitySystem.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Enumerations;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;

    [TestClass]
    public class RepositoryTests
    {
        private IRepository<User> users;

        [TestInitialize]
        public void TestInitialize()
        {
            this.users = new Repository<User>();
        }

        [TestMethod]
        public void Get_ValidId_SHouldReturnElement()
        {
            var userList = new List<User>()
            {
                new User("Pesho","123456",Role.Lecturer),
                new User("Gosho","654321",Role.Student)
            };

            foreach (var user in userList)
            {
                this.users.Add(user);
            }

            const int Id = 1;
            var actualUser = this.users.Get(Id);

            Assert.AreEqual(userList[Id - 1], actualUser);
        }

        [TestMethod]
        public void Get_InValidId_SHouldReturnDefault()
        {
            const int Id = 1;
            var actualUser = this.users.Get(Id);

            Assert.AreEqual(default(User), actualUser);
        }

        [TestMethod]
        public void Get_InValidId_SHouldReturnDefaultUser()
        {
            var userList = new List<User>()
            {
                new User("Pesho","123456",Role.Lecturer),
                new User("Gosho","654321",Role.Student)
            };

            foreach (var user in userList)
            {
                this.users.Add(user);
            }

            int id = userList.Count + 1;
            var actualUser = this.users.Get(id);

            Assert.AreEqual(default(User), actualUser);
        }
    }
}
