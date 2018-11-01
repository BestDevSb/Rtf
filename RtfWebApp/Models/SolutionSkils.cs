using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
namespace RtfWebApp.Models
{
    [DataContract]    
    public class SolutionSkils
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [ForeignKey(nameof(Solution))]
        public int SolutionId { get; set; }
        public Solution Solution { get; set; }

        [DataMember]
        [ForeignKey(nameof(Skil))]
        public int SkilId { get; set; }
        public Skil Skil { get; set; }
    }
}
