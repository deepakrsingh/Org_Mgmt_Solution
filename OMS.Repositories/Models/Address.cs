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
    [Table("Address", Schema = "Person")]
    public class Address
    {
        public int AddressId { get; set; }
        [ForeignKey("AddressType")]
        public int AddressTypeId { get; set; }
        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
        public string PostalCode { get; set; }
        public string SpatialLocation { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Timestamp]
        public byte[] Rowguid { get; set; }
        [IgnoreDataMember]
        public virtual State State { get; set; }
        [IgnoreDataMember]
        public virtual AddressType AddressType { get; set; }

    }
}
