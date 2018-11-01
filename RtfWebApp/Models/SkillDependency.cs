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
        public int SkilAId { get; set; }
        [DataMember]
        
        public int SkilBId { get; set; }
        
        [DataMember]
        public double Weight { get; set; }
    }
}
