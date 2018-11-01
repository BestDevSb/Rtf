using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Models
{
    public class RecomendedEmployees
    {
        public int EmployeeId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalRate { get; set; }
        public double TotalWeight { get; set; }
        public int IntersectCount { get; set; }
    }
}
