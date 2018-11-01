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
    public class SkillDependency: IHaveId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int SkillAId { get; set; }
        public Skill SkillA { get; set; }
        [DataMember]        
        public int SkillBId { get; set; }
        public Skill SkillB { get; set; }
        [DataMember]
        public double Weight { get; set; }
    }
}
