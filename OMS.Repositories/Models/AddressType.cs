using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Repository.Models
{
    [Table("AddressType", Schema = "Person")]
    public class AddressType
    {
        public int AddressTypeId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Timestamp]
        public byte[] Rowguid { get; set; }
    }
}
