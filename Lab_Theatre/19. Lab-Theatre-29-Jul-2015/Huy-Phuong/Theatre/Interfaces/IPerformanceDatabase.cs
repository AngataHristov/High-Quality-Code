namespace TheatreSystem.Interfaces
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a performances database, holdings a diferent types of performances
    /// and a set of commands about them.
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Adds a theatre to the list of performances by given theatre name.
        /// </summary>
        /// <param name="theatreName">The name of the theatre</param>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Search and returns list of theatres from the performance database.
        /// </summary>
        /// <returns>List of theatres.</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Adds performance to the database by givem name og theatre, performance title,
        /// starting time of the performance, performance's duration and price.
        /// </summary>
        /// <param name="theatreName">The name of the theatre</param>
        /// <param name="performanceTitle">The title of the performance</param>
        /// <param name="startDateTime">Starting time of the performance</param>
        /// <param name="duration">Performance's duration</param>
        /// <param name="price">Price of the performance</param>
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// Searches and returns list of all performances in the database.
        /// </summary>
        /// <returns>Returns list of all performances in the database.</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Searches in the database and returns list of all performances by given theatre name.
        /// </summary>
        /// <param name="theatreName">The name of the theatre</param>
        /// <returns>Returns list of performances</returns>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}
