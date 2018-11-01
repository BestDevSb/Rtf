using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Models
{
    public class Rating: IHaveId
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public double Weight { get; set; }
        public int Rate { get; set; }
    }
}
