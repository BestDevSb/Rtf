using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace RtfWebApp.Models
{
    [DataContract]
    public class Solution: IHaveId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
    }
}
