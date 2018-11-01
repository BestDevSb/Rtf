using RtfWebApp.Controllers.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Models.View
{
    public class SolutionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SkilInfo[] Skills { get; set; }
        public Employee[] Employees { get; set; }

        public SolutionResolution Resolution {get;set;}
    }
}
