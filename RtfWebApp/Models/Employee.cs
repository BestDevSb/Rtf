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
    public class Employee: IHaveId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
