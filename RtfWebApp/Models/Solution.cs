using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Models
{
    public class Solution: IHaveId
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Skil> RequieredSkils { get; set; }
    }
}
