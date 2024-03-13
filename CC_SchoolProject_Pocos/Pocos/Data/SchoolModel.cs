using Pocos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Pocos.Data
{
    public partial class SchoolModel : DbContext
    {
        public SchoolModel()
            : base("name=SchoolModel")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Assessment> Assessments { get; set; }

        public virtual DbSet<Guardian> Guardians { get; set; }

        public virtual DbSet<Learner> Learners { get; set; }

        public virtual DbSet<Mark> Marks { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }
    }
}
