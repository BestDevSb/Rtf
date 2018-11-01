using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Models
{
    public class Skil: IHaveId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SkillCategory Category { get; set; }

    }
}
