using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Models
{
    public class Achivment: IHaveId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Skil Skil { get; set; }
    }
}
