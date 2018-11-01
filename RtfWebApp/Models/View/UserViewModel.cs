using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Models.View
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public int AvatarId { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public SkillGroup[] SkilGroups { get; set; }
        /// <summary>
        /// Качество обратной связи - насколько оценки этого пользователя актуальны
        /// </summary>
        public double FeedBackQuality { get; set; }

        public List<UserViewModel> SimilarUsers { get; set; }
    }

    public class SkillGroup
    {
        public string Name { get; set; }

        public SkilInfo[] Skils { get; set; }
    }

    public class SkilInfo
    {
        public string Name { get; set; }
        public double Rate { get; set; }
    }
}
