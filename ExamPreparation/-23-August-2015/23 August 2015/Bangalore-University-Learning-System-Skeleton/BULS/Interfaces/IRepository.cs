namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines repository, holding some methodes for manipulation of database
    /// (like: Adding item, getting item by specific criteria,getting all item).
    /// </summary>
    /// <typeparam name="T">custome parameter type</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets all items in repository.
        /// </summary>
        /// <returns>Collection of all items in repository.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets item from repository by given ID.
        /// </summary>
        /// <param name="id">ID of item</param>
        /// <returns>The item with the given ID in case of success or throws an exception,
        /// if item with the given ID is not found</returns>
        T Get(int id);

        /// <summary>
        /// Adds the given item to the repository.
        /// </summary>
        /// <param name="item">The item for adding</param>
        void Add(T item);
    }
}
