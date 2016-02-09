namespace TheatreSystem.Core.Factories
{
    using System;

    public static class PerformanceFactory
    {
        public static Performance CreatePerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            return new Performance(theatreName, performanceTitle, startDateTime, duration, price);
        }
    }
}
