using System;
using System.Collections.Generic;

namespace CC_SchoolProject_RestApi.Models
{
    public partial class Address
    {
        public Address()
        {
            Guardians = new HashSet<Guardian>();
            Teachers = new HashSet<Teacher>();
        }

        public int AddressId { get; set; }
        public string? AddressLine { get; set; }
        public string? Suburb { get; set; }
        public string? PostalCode { get; set; }

        public virtual ICollection<Guardian> Guardians { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
