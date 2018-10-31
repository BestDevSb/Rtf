namespace Rtf.Data.Model
{
    /// <summary>
    /// User Credentials
    /// </summary>
    public class UserCredentials
    {
        public int Id { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
