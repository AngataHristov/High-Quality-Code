namespace BangaloreUniversitySystem.Tests
{
    using System;
    using System.Linq;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Enumerations;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CoursesTests
    {
        private IBangaloreUniversityData mockedData;
        private Course course;

        [TestInitialize]
        public void InitializeMock()
        {
            var dataMock = new Mock<IBangaloreUniversityData>();
            var courseRepoMock = new Mock<IRepository<Course>>();
            this.course = new Course("C# for babies");
            courseRepoMock.Setup(r => r.Get(It.IsAny<int>()))
                .Returns(this.course);

            dataMock.Setup(d => d.Courses)
                .Returns(courseRepoMock.Object);

            this.mockedData = dataMock.Object;
        }

        [TestMethod]
        public void AddLectur_ValidCourseId_ShouldAddToCourse()
        {
            var controller = new CoursesController(this.mockedData, new User("nasko", "123456", Role.Lecturer));

            var view = controller.AddLecture(5, DateTime.Now.ToString());

            Assert.IsNotNull(view);
            Assert.AreEqual(this.course.Lectures.First().Name, DateTime.Now.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddLecture_InvalidCourseId_ShouldThrow()
        {
            var dataMock = new Mock<IBangaloreUniversityData>();
            var courseRepoMock = new Mock<IRepository<Course>>();
            this.course = null;

            courseRepoMock.Setup(r => r.Get(It.IsAny<int>()))
                .Returns(this.course);

            dataMock.Setup(d => d.Courses)
                .Returns(courseRepoMock.Object);

            this.mockedData = dataMock.Object;

            var controller = new CoursesController(this.mockedData, new User("nasko", "123456", Role.Lecturer));

            var view = controller.AddLecture(5, DateTime.Now.ToString());
        }
    }
}
