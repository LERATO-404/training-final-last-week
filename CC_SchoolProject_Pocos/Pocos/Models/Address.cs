using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos.Models
{
    [Table("Addresses")]
    public class Address
    {
        [Key, Column("Address_Id")]
        public int AddressId { get; set; }

        [Column("Address_Line")]
        public string AddressLine { get; set; }

        [Column("Suburb")]
        public string Suburb { get; set; }

        [Column("Postal_Code")]
        public string PostalCode { get; set; }

        public virtual ICollection<Guardian> Guardians { get; set; }
    }
}
