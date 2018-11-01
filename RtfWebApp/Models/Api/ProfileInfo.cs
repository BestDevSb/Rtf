namespace RtfWebApp.Controllers.Models.Api
{
    public class ProfileInfo
    {
        public int SameId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Совместимость в процентах 0-100
        /// Рассчитывается на основе навыков и оценок
        /// </summary>
        public int Compatibility { get; set; }
    }
}