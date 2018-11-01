using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Models
{
    public class EmployeeRating
    {
        public int EmployeeId { get; set; }
        public double Rate { get; set; }
        public double Weight { get; set; }
        public int TotalRate { get; set; }
        public int RateCount { get; set; }
        public string EmployeeName { get; set; }
        public int SkillId { get; set; }
        public string SkillTitle { get; set; }
    }
}
