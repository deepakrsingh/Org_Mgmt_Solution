using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Repository.Models
{
    [Table("Person", Schema = "Person")]
    public class Person
    {
        public int PersonId { get; set; }
        [MaxLength(2)]
        public string PersonType { get; set; }
        [MaxLength(8)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [ForeignKey("BusinessEntity")]
        public int BusinessEntityId { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Timestamp]
        public byte[] Rowguid { get; set; }
        [IgnoreDataMember]
        public virtual BusinessEntity BusinessEntity { get; set; }
    }
}
