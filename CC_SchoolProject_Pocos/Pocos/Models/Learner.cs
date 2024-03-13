using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos.Models
{
    [Table("Learners")]
    public class Learner
    {
        [Key, Column("Learner_Id")]
        public int LearnerId { get; set; }

        [Column("First_Name")]
        public string FirstName { get; set; }

        [Column("Last_Name")]
        public string LastName { get; set; }

        [Column("Start_Date")]
        public DateTime StartDate { get; set; }

        [Column("Date_Of_Birth")]
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("Guardians"), Column("Guardian_Id")]
        public int GuardianId { get; set; }
        public virtual Guardian Guardians { get; set; }
    }
}
