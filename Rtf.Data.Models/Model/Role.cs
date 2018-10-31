namespace Rtf.Data.Model
{
    using Constants.Base;

    /// <summary>
    /// Role
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public Roles Code { get; set; }
    }
}
