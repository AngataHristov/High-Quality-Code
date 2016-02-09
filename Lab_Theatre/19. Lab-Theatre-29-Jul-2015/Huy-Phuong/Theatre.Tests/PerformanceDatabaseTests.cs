namespace Theatre.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TheatreSystem;
    using TheatreSystem.Exceptions;
    using TheatreSystem.Interfaces;

    [TestClass]
    public class PerformanceDatabaseTests
    {
        private IPerformanceDatabase performanceDatabase;

        [TestInitialize]
        public void Initialize()
        {
            this.performanceDatabase = new PerformanceDatabase();
        }

        [TestMethod]
        public void AddPerformance_EmptyDataBase_ShouldOK()
        {
            this.performanceDatabase.AddTheatre("Theatre 199");
            this.performanceDatabase.AddPerformance("Theatre 199", "Duende", new DateTime(2015, 01, 20, 20, 00, 00), new TimeSpan(01, 30, 00), 14.5m);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void AddPerformance_NoTheatreFound_ShouldThrow()
        {
            this.performanceDatabase.AddTheatre("Theatre Sofia");
            this.performanceDatabase.AddPerformance("Theatre 199", "Duende", new DateTime(2015, 01, 20, 20, 00, 00), new TimeSpan(01, 30, 00), 14.5m);
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void AddPerformance_InvalidTimeDuration_ShouldThrow()
        {
            this.performanceDatabase.AddTheatre("Theatre 199");
            this.performanceDatabase.AddPerformance("Theatre 199", "Duende", new DateTime(2015, 01, 20, 20, 00, 00), new TimeSpan(01, 30, 00), 14.5m);
            this.performanceDatabase.AddPerformance("Theatre 199", "Bella Donna", new DateTime(2015, 01, 20, 20, 00, 00), new TimeSpan(01, 30, 00), 14.5m);
        }

        [TestMethod]
        public void ListTheatres_EmptyDataBase_ShouldPass()
        {
            var result = this.performanceDatabase.ListTheatres();
        }

        [TestMethod]
        public void ListTheatres_NonEmptyDataBase_ShhouldReturnListOfTheatres()
        {
            this.performanceDatabase.AddTheatre("Theatre 199");
            this.performanceDatabase.AddPerformance("Theatre 199", "Duende", new DateTime(2015, 01, 20, 20, 00, 00), new TimeSpan(01, 30, 00), 14.5m);
            this.performanceDatabase.AddPerformance("Theatre 199", "Bella Donna", new DateTime(2015, 03, 20, 20, 00, 00), new TimeSpan(01, 50, 00), 24.5m);

            string expectedPerformances = "Theatre 199";
            string performances = string.Join(" ", this.performanceDatabase.ListTheatres());

            Assert.AreEqual(expectedPerformances, performances);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void ListPerformances_ByNonExistingheatreName_ShouldThrow()
        {
            this.performanceDatabase.AddTheatre("Theatre 199");
            this.performanceDatabase.AddPerformance("Theatre 199", "Duende", new DateTime(2015, 01, 20, 20, 00, 00), new TimeSpan(01, 30, 00), 14.5m);

            this.performanceDatabase.ListPerformances("Theatre Sofia");
        }

        [TestMethod]
        public void ListPerformances_ByExistingheatreName_ShouldPass()
        {
            this.performanceDatabase.AddTheatre("Theatre 199");
            this.performanceDatabase.AddPerformance("Theatre 199", "Duende", new DateTime(2015, 01, 20, 20, 00, 00), new TimeSpan(01, 30, 00), 14.5m);
            this.performanceDatabase.AddPerformance("Theatre 199", "Bella Donna", new DateTime(2015, 03, 20, 20, 00, 00), new TimeSpan(01, 50, 00), 24.5m);

            IEnumerable<Performance> info = this.performanceDatabase.ListPerformances("Theatre 199");
            var names = new List<string>();
            foreach (var performance in info)
            {
                names.Add(performance.PerformanceTitle);
            }

            string expectedResult = "Duende" + " " + "Bella Donna";
            string result = string.Join(" ", names);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
