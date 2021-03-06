﻿using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
namespace RtfWebApp.Models
{
    [DataContract]    
    public class SolutionSkils : IHaveId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [ForeignKey(nameof(Solution))]
        public int SolutionId { get; set; }
        public Solution Solution { get; set; }

        [DataMember]
        [ForeignKey(nameof(Skill))]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
