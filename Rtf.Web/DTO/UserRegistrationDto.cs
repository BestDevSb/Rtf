namespace Rtf.Web.DTO
{
    /// <summary>
    /// Регистрационные данные
    /// </summary>
    public class UserRegistrationDto
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
