namespace ShowFeed.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The update.
    /// </summary>
    [Table("Update")]
    public class Update : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Update"/> class.
        /// </summary>
        public Update()
        {
            this.Series = new List<Series>();
            this.Episodes = new List<Episode>();
        }

        /// <summary>
        /// Gets or sets the time when the update started as a unix time stamp.
        /// </summary>
        public virtual int Started { get; set; }

        /// <summary>
        /// Gets or sets the time when the update finished as a unix time stamp.
        /// </summary>
        public virtual int Finished { get; set; }

        /// <summary>
        /// Gets or sets the update time as a unix time stamp.
        /// </summary>
        public virtual int UpdateTime { get; set; }

        /// <summary>
        /// Gets or sets the updated series.
        /// </summary>
        public virtual ICollection<Series> Series { get; set; }

        /// <summary>
        /// Gets or sets the updated episodes.
        /// </summary>
        public virtual ICollection<Episode> Episodes { get; set; }
    }
}