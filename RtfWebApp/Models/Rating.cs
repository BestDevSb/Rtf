using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RtfWebApp.Models
{
    [DataContract]
    public class Rating: IHaveId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [DataMember]
        public double Weight { get; set; }
        [DataMember]
        public int Rate { get; set; }
        [DataMember]
        [ForeignKey(nameof(Skill))]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
