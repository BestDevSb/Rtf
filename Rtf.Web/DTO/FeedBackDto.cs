namespace Rtf.Web.DTO
{
    /// <summary>
    /// Feedback
    /// </summary>
    public class FeedBackDto
    {
        /// <summary>
        /// From User
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// To User
        /// </summary>
        public int To { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        public int Rate { get; set; }
        
        /// <summary>
        /// Категория
        /// </summary>
        public int Category { get; set; }
    }
}
