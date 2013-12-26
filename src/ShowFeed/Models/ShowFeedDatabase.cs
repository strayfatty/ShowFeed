namespace ShowFeed.Models
{
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// The show feed database.
    /// </summary>
    public class ShowFeedDatabase : DbContext, IDatabase
    {
        /// <summary>
        /// The connection string name.
        /// </summary>
        public const string ConnectionStringName = "ShowFeedDatabase";

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowFeedDatabase"/> class.
        /// </summary>
        public ShowFeedDatabase()
            : base(ConnectionStringName)
        {
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<T>(T entity) where T : Entity
        {
            this.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Loads an entity from the database.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="id">The entity id.</param>
        /// <returns>The entity or null.</returns>
        public T Load<T>(int id) where T : Entity
        {
            return this.Set<T>().Find(id);
        }

        /// <summary>
        /// Queries the database for a specific entity type.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        public IQueryable<T> Query<T>() where T : Entity
        {
            return this.Set<T>();
        }

        /// <summary>
        /// Saves all changes to the database.
        /// </summary>
        void IDatabase.SaveChanges()
        {
            this.SaveChanges();
        }

        /// <summary>
        /// Stores a new entity in the database.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="entity">The entity.</param>
        public void Store<T>(T entity) where T : Entity
        {
            this.Set<T>().Add(entity);
        }

        /// <summary>
        /// The on model creating event handler.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureModel(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Configures the database models.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void ConfigureModel(DbModelBuilder modelBuilder)
        {
            var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
            var entityTypes = typeof(Entity).Assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Entity)) && !x.IsAbstract);

            foreach (var type in entityTypes)
            {
                entityMethod.MakeGenericMethod(type)
                    .Invoke(modelBuilder, new object[] { });
            }
        }
    }
}