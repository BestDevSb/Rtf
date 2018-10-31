using System;

namespace Rtf.Data.Model
{
    /// <summary>
    /// Feedback
    /// </summary>
    public class FeedBack
    {
        public int Id { get; set; }

        /// <summary>
        /// From
        /// </summary>
        public User From { get; set; }

        /// <summary>
        /// To
        /// </summary>
        public User To { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// Rate category
        /// </summary>
        public RateCategory Category { get; set; }

        /// <summary>
        /// Create date
        /// </summary>
        public DateTime Created { get; set; }
    }
}
