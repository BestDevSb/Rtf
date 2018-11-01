using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace RtfWebApp.Models
{
    [DataContract]
    public class Skil: IHaveId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public SkillCategory Category { get; set; }

        public virtual List<SkillDependency> Dependencies { get; set; }
        public virtual List<SkillDependency> Dependendenties { get; set; }
    }
}
