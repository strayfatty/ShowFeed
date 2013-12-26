namespace ShowFeed.Models
{
    using System.Linq;

    /// <summary>
    /// Database session interface.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="entity">The entity.</param>
        void Delete<T>(T entity) where T : Entity;

        /// <summary>
        /// Loads an entity from the database.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="id">The entity id.</param>
        /// <returns>The entity or null.</returns>
        T Load<T>(int id) where T : Entity;

        /// <summary>
        /// Queries the database for a specific entity type.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        IQueryable<T> Query<T>() where T : Entity;

        /// <summary>
        /// Saves all changes to the database.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Stores a new entity in the database.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entity">The entity.</param>
        void Store<T>(T entity) where T : Entity;
    }
}
