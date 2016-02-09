namespace TheatreSystem
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Core.Factories;
    using Exceptions;
    using Interfaces;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly IDictionary<string, SortedSet<Performance>> performances;

        public PerformanceDatabase()
        {
            this.performances = new SortedDictionary<string, SortedSet<Performance>>();
        }

        public void AddTheatre(string theatreName)
        {
            if (this.performances.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException(Constants.DuplicateTheatreMsg);
            }

            this.performances[theatreName] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatres = this.performances.Keys;
            return theatres;
        }

        public void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            if (!this.performances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException(Constants.TheatreDoesNotExistMsg);
            }

            var machedPerformances = this.performances[theatreName];
            var totalTime = startDateTime + duration;
            if (this.CheckPerformance(machedPerformances, startDateTime, totalTime))
            {
                throw new TimeDurationOverlapException(Constants.TimeOrDurationOverlapMsg);
            }

            var performance = PerformanceFactory.CreatePerformance(theatreName, performanceTitle, startDateTime, duration, price);
            machedPerformances.Add(performance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.performances.Keys;
            var result = new List<Performance>();
            foreach (var theatre in theatres)
            {
                var performances = this.performances[theatre];
                result.AddRange(performances);
            }

            return result;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.performances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException(Constants.TheatreDoesNotExistMsg);
            }

            var machedPerformances = this.performances[theatreName];
            return machedPerformances;
        }

        public bool CheckPerformance(IEnumerable<Performance> performances, DateTime startTime, DateTime totalTime)
        {
            bool isInInterval = false;
            foreach (var performance in performances)
            {
                var startDateTime = performance.StartDateTime;
                var endDateTime = performance.StartDateTime + performance.Duration;
                isInInterval = (startDateTime <= startTime && startTime <= endDateTime) ||
                             (startDateTime <= totalTime && totalTime <= endDateTime) ||
                             (startTime <= startDateTime && startDateTime <= totalTime) ||
                             (startTime <= endDateTime && endDateTime <= totalTime);
                if (isInInterval)
                {
                    return true;
                }
            }

            return isInInterval;
        }
    }
}
