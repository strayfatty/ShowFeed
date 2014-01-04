namespace ShowFeed.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The update.
    /// </summary>
    [Table("Update")]
    public class Update ////: Entity
    {
        /// <summary>
        /// Gets or sets the time when the update started as a unix time stamp.
        /// </summary>
        public virtual int Started { get; set; }

        /// <summary>
        /// Gets or sets the time when the update finished as a unix time stamp.
        /// </summary>
        public virtual int Finished { get; set; }

        /// <summary>
        /// Gets or sets the number of series that have been updated.
        /// </summary>
        public virtual int NumberOfSeriesUpdated { get; set; }

        /// <summary>
        /// Gets or sets the number of updated that have been updated.
        /// </summary>
        public virtual int NumberOfEpisodesUpdated { get; set; }
    }
}