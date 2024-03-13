using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CC_SchoolProject_RestApi.Models
{
    public partial class CodeCrusaders_School_Management_DBContext : DbContext
    {
        public CodeCrusaders_School_Management_DBContext()
        {
        }

        public CodeCrusaders_School_Management_DBContext(DbContextOptions<CodeCrusaders_School_Management_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Assessment> Assessments { get; set; } = null!;
        public virtual DbSet<Guardian> Guardians { get; set; } = null!;
        public virtual DbSet<Learner> Learners { get; set; } = null!;
        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.AddressLine).HasColumnName("Address_Line");

                entity.Property(e => e.PostalCode).HasColumnName("Postal_Code");
            });

            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.HasIndex(e => e.SubjectId, "IX_SubjectId");

                entity.Property(e => e.AssessmentId).HasColumnName("Assessment_Id");

                entity.Property(e => e.AssessmentName).HasColumnName("Assessment_Name");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Due_Date");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_dbo.Assessments_dbo.Subjects_SubjectId");
            });

            modelBuilder.Entity<Guardian>(entity =>
            {
                entity.HasIndex(e => e.AddressId, "IX_Address_Id");

                entity.Property(e => e.GuardianId).HasColumnName("Guardian_Id");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.FirstName).HasColumnName("First_Name");

                entity.Property(e => e.LastName).HasColumnName("Last_Name");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Guardians)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_dbo.Guardians_dbo.Addresses_Address_Id");
            });

            modelBuilder.Entity<Learner>(entity =>
            {
                entity.HasIndex(e => e.GuardianId, "IX_Guardian_Id");

                entity.Property(e => e.LearnerId).HasColumnName("Learner_Id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Birth");

                entity.Property(e => e.FirstName).HasColumnName("First_Name");

                entity.Property(e => e.GuardianId).HasColumnName("Guardian_Id");

                entity.Property(e => e.LastName).HasColumnName("Last_Name");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Date");

                entity.HasOne(d => d.Guardian)
                    .WithMany(p => p.Learners)
                    .HasForeignKey(d => d.GuardianId)
                    .HasConstraintName("FK_dbo.Learners_dbo.Guardians_Guardian_Id");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasIndex(e => e.AssessmentId, "IX_Assessment_Id");

                entity.HasIndex(e => e.LearnerId, "IX_Learner_Id");

                entity.Property(e => e.MarkId).HasColumnName("Mark_Id");

                entity.Property(e => e.AssessmentId).HasColumnName("Assessment_Id");

                entity.Property(e => e.LearnerId).HasColumnName("Learner_Id");

                entity.Property(e => e.MarkObtained).HasColumnName("Mark_Obtained");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.AssessmentId)
                    .HasConstraintName("FK_dbo.Marks_dbo.Assessments_Assessment_Id");

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.LearnerId)
                    .HasConstraintName("FK_dbo.Marks_dbo.Learners_Learner_Id");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId).HasColumnName("Subject_Id");

                entity.Property(e => e.SubjectCode).HasColumnName("Subject_Code");

                entity.Property(e => e.SubjectDescription).HasColumnName("Subject_Description");

                entity.Property(e => e.SubjectName).HasColumnName("Subject_Name");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasIndex(e => e.AddressId, "IX_Address_Id");

                entity.Property(e => e.TeacherId).HasColumnName("Teacher_Id");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.ContactNumber).HasColumnName("Contact_Number");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Birth");

                entity.Property(e => e.EmailAddress).HasColumnName("Email_Address");

                entity.Property(e => e.FirstName).HasColumnName("First_Name");

                entity.Property(e => e.LastName).HasColumnName("Last_Name");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Date");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_dbo.Teachers_dbo.Addresses_Address_Id");
            });

            modelBuilder.Entity<TeacherSubject>(entity =>
            {
                entity.HasIndex(e => e.SubjectId, "IX_Subject_Id");

                entity.HasIndex(e => e.TeacherId, "IX_Teacher_Id");

                entity.Property(e => e.TeacherSubjectId).HasColumnName("TeacherSubject_Id");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_Id");

                entity.Property(e => e.TeacherId).HasColumnName("Teacher_Id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeacherSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_dbo.TeacherSubjects_dbo.Subjects_Subject_Id");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherSubjects)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_dbo.TeacherSubjects_dbo.Teachers_Teacher_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
