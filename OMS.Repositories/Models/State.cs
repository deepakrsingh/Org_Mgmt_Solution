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
    [Table("State", Schema = "Person")]
    public class State
    {
        public int StateId { get; set; }
        [MaxLength(50)]
        public string StateName { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public DateTime ModifiedDate { get; set; }

        [IgnoreDataMember]
        public virtual Country Country { get; set; }
    }
}
