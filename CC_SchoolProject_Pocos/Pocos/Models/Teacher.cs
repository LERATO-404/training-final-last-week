using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos.Models
{
    [Table("Teachers")]
    public class Teacher
    {
        [Key, Column("Teacher_Id")]
        public int TeacherId { get; set; }

        [Column("First_Name")]
        public string FirstName { get; set; }

        [Column("Last_Name")]
        public string LastName { get; set; }

        [Column("Date_Of_Birth")]
        public DateTime? DateOfBirth { get; set; } = null;

        [Column("Contact_Number")]
        public string ContactNumber { get; set; }

        [Column("Email_Address")]
        public string EmailAddress { get; set; }

        [ForeignKey("Addresses"), Column("Address_Id")]
        public int? AddressId { get; set; }
        public virtual Address Addresses { get; set; }

        [Column("Username")]
        public string Username { get; set; }

        [Column("Start_Date")]
        public DateTime? StartDate { get; set; } = null;

        [Column("Status")]
        public string Status { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
