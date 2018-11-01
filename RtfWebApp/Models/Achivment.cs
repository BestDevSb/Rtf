using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
namespace RtfWebApp.Models
{
    [DataContract]
    public class Achivment: IHaveId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        [ForeignKey(nameof(Skil))]
        public int SkilId { get; set; }
        public Skil Skil { get; set; }
    }
}
