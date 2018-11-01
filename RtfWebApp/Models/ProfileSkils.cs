using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtfWebApp.Models
{
    public class ProfileSkils : IHaveId
    {
        public int Id { get; set; }
        public Profile Profile {get;set;}
        public Skil Skil { get; set; }
    }
}
