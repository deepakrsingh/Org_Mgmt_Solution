using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Repository.Models
{
    [Table("BusinessEntity", Schema ="Person")]
    public class BusinessEntity
    {
        public int BusinessEntityId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessType { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Timestamp]
        public byte[] Rowguid { get; set; }

    }
}
