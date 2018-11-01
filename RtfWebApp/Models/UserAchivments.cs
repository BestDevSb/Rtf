using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace RtfWebApp.Models
{
    [DataContract]
    public class EmployeeAchivments: IHaveId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [DataMember]
        [ForeignKey(nameof(Achivment))]
        public int AchivmentId { get; set; }
        public Achivment Achivment { get; set; }
    }
}
