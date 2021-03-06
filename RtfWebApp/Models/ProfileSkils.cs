﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RtfWebApp.Models
{
    [DataContract]
    public class ProfileSkills : IHaveId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        public Profile Profile {get;set;}
        [DataMember]
        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
