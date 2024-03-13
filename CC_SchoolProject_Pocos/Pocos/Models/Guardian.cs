using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos.Models
{

    [Table("Guardians")]
    public class Guardian
    {
        [Key, Column("Guardian_Id")]
        public int GuardianId { get; set; }
        [Column("First_Name")]
        public string FirstName { get; set; }

        [Column("Last_Name")]
        public string LastName { get; set; }

        [Column("Relationship")]
        public string Relationship { get; set; }

        [Column("Contact")]
        public string Contact { get; set; }

        [ForeignKey("Addresses"), Column("Address_Id")]
        public int AddressId { get; set; }
        public virtual Address Addresses { get; set; }

        public virtual ICollection<Learner> Learners { get; set; }
    }
}
