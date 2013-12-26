namespace ShowFeed.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Base class for all database entities.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}