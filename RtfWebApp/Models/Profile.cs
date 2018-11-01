using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Models
{
    public class Profile: IHaveId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Skil> Skills { get; set; }
    }
}
