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
    public class EmployeeSolutions
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [DataMember]
        [ForeignKey(nameof(Solution))]
        public int SolutionId { get; set; }
        public Solution Solution { get; set; }
    }
}
