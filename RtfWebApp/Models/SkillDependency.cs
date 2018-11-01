using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Models
{
    public class SkillDependency: IHaveId
    {
        public int Id { get; set; }
        public int SkilAId { get; set; }
        public Skil SkilA { get; set; }
        public int SkilBId { get; set; }
        public Skil SkilB { get; set; }
        public double Weight { get; set; }
    }
}
