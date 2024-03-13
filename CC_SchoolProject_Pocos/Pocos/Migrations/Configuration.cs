namespace Pocos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Pocos.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Pocos.Data.SchoolModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pocos.Data.SchoolModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Teachers 
            context.Teachers.AddOrUpdate(t => t.TeacherId,
                new Teacher() { TeacherId = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1985, 5, 15), ContactNumber = "083-456-7890", EmailAddress = "john.doe@example.com", AddressId = 1, Username = "johndoe", StartDate = new DateTime(2020, 9, 1), Status = "Active" },
                new Teacher() { TeacherId = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1978, 8, 22), ContactNumber = "087-654-3210", EmailAddress = "jane.smith@example.com", AddressId = 2, Username = "janesmith", StartDate = new DateTime(2019, 10, 3), Status = "Not Active" },
                new Teacher() { TeacherId = 3, FirstName = "David", LastName = "Johnson", DateOfBirth = new DateTime(1990, 3, 7), ContactNumber = "087-123-4567", EmailAddress = "david.johnson@example.com", AddressId = 3, Username = "davidj", StartDate = new DateTime(2022, 2, 15), Status = "Active" },
                new Teacher() { TeacherId = 4, FirstName = "Emily", LastName = "Brown", DateOfBirth = new DateTime(1982, 12, 10), ContactNumber = "062-333-3333", EmailAddress = "emily.b@example.com", AddressId = 4, Username = "emilybrown", StartDate = new DateTime(2018, 7, 12), Status = "Active" },
                new Teacher() { TeacherId = 5, FirstName = "Jason", LastName = "Miller", DateOfBirth = new DateTime(1984, 5, 16), ContactNumber = "078-456-7890", EmailAddress = "jason.miller@example.com", AddressId = 5, Username = "jasonmiller", StartDate = new DateTime(2016, 9, 1), Status = "Not Active" },
                new Teacher() { TeacherId = 6, FirstName = "Kelly", LastName = "Brown", DateOfBirth = new DateTime(1980, 7, 21), ContactNumber = "061-654-3210", EmailAddress = "kelly.brown@example.com", AddressId = 6, Username = "kellybrown", StartDate = new DateTime(2017, 9, 3), Status = "Active" },
                new Teacher() { TeacherId = 7, FirstName = "Derick", LastName = "Bradely", DateOfBirth = new DateTime(1992, 3, 8), ContactNumber = "068-123-4567", EmailAddress = "derrick.jbradley@example.com", AddressId = 7, Username = "derrickb", StartDate = new DateTime(2022, 3, 17), Status = "Not Active" },
                new Teacher() { TeacherId = 8, FirstName = "Louisse", LastName = "Naidoo", DateOfBirth = new DateTime(1983, 11, 10), ContactNumber = "072-333-3333", EmailAddress = "louise.n@example.com", AddressId = 8, Username = "louisenaidoo", StartDate = new DateTime(2018, 8, 12), Status = "Active" },
                new Teacher() { TeacherId = 9, FirstName = "Jimmy", LastName = "Sky", DateOfBirth = new DateTime(1982, 10, 10), ContactNumber = "072-326-309", EmailAddress = "jimmy.s@example.com", AddressId = 9, Username = "jimmysky", StartDate = new DateTime(2023, 8, 12), Status = "Not Active" },
                new Teacher() { TeacherId = 10, FirstName = "Sam", LastName = "Smith", DateOfBirth = new DateTime(1988, 11, 11), ContactNumber = "082-333-3987", EmailAddress = "sam.smith@example.com", AddressId = 10, Username = "samsmith", StartDate = new DateTime(2018, 6, 12), Status = "Active" }
            );

            // Address
            context.Addresses.AddOrUpdate(a => a.AddressId,
                new Address() { AddressId = 1, AddressLine = "123 Marvin St", Suburb = "City Center", PostalCode = "12345" },
                new Address() { AddressId = 2, AddressLine = "789 Runaway St", Suburb = "Suburbia", PostalCode = "67890" },
                new Address() { AddressId = 3, AddressLine = "456 HighRoad St", Suburb = "Uptown", PostalCode = "45678" },
                new Address() { AddressId = 4, AddressLine = "987 Pine St", Suburb = "Village", PostalCode = "98765" },
                new Address() { AddressId = 5, AddressLine = "321 Birch St", Suburb = "Hillside", PostalCode = "32100" },
                new Address() { AddressId = 6, AddressLine = "555 Elm St", Suburb = "Uptown", PostalCode = "45678" },
                new Address() { AddressId = 7, AddressLine = "789 Oak St", Suburb = "City Center", PostalCode = "12345" },
                new Address() { AddressId = 8, AddressLine = "654 Pine St", Suburb = "Village", PostalCode = "98765" },
                new Address() { AddressId = 9, AddressLine = "111 Maple St", Suburb = "Suburbia", PostalCode = "67890" },
                new Address() { AddressId = 10, AddressLine = "112 Maple St", Suburb = "Suburbia", PostalCode = "67890" }
            );

            // Learner
            context.Learners.AddOrUpdate(l => l.LearnerId,
                new Learner() { LearnerId = 1, FirstName = "Sam", LastName = "Williams", DateOfBirth = new DateTime(2005, 4, 8), GuardianId = 1, StartDate = new DateTime(2018, 1, 11) },
                new Learner() { LearnerId = 2, FirstName = "Olivia", LastName = "Johnson", DateOfBirth = new DateTime(2008, 7, 12), GuardianId = 10, StartDate = new DateTime(2021, 2, 15) },
                new Learner() { LearnerId = 3, FirstName = "Liam", LastName = "Smith", DateOfBirth = new DateTime(2009, 2, 21), GuardianId = 3, StartDate = new DateTime(2022, 2, 1) },
                new Learner() { LearnerId = 4, FirstName = "Emma", LastName = "Brown", DateOfBirth = new DateTime(2010, 11, 29), GuardianId = 4, StartDate = new DateTime(2023, 1, 13) },
                new Learner() { LearnerId = 5, FirstName = "Tomas", LastName = "Rock", DateOfBirth = new DateTime(2005, 4, 8), GuardianId = 5, StartDate = new DateTime(2018, 2, 2) },
                new Learner() { LearnerId = 6, FirstName = "Frank", LastName = "Johnson", DateOfBirth = new DateTime(2008, 7, 12), GuardianId = 10, StartDate = new DateTime(2021, 1, 15) },
                new Learner() { LearnerId = 7, FirstName = "Liam", LastName = "Smith", DateOfBirth = new DateTime(2009, 2, 21), GuardianId = 7, StartDate = new DateTime(2022, 2, 1) },
                new Learner() { LearnerId = 8, FirstName = "Johnny", LastName = "Brown", DateOfBirth = new DateTime(2010, 11, 29), GuardianId = 9, StartDate = new DateTime(2023, 1, 13) },
                new Learner() { LearnerId = 9, FirstName = "Sarah", LastName = "Ury", DateOfBirth = new DateTime(2007, 9, 16), GuardianId = 1, StartDate = new DateTime(2020, 2, 13) },
                new Learner() { LearnerId = 10, FirstName = "Lanny", LastName = "Ethan", DateOfBirth = new DateTime(2004, 5, 7), GuardianId = 2, StartDate = new DateTime(2017, 2, 10) }
            );

            // Assessment
            context.Assessments.AddOrUpdate(ass => ass.AssessmentId,
                new Assessment() { AssessmentId = 1, AssessmentName = "Maths Assignment", SubjectId = 101, DueDate = new DateTime(2023, 3, 15) },
                new Assessment() { AssessmentId = 2, AssessmentName = "Biology Project", SubjectId = 102, DueDate = new DateTime(2023, 4, 30) },
                new Assessment() { AssessmentId = 3, AssessmentName = "History Research Paper", SubjectId = 103, DueDate = new DateTime(2023, 4, 20) },
                new Assessment() { AssessmentId = 4, AssessmentName = "Literary Analysis Essay", SubjectId = 104, DueDate = new DateTime(2023, 5, 10) },
                new Assessment() { AssessmentId = 5, AssessmentName = "Solo Project 1", SubjectId = 105, DueDate = new DateTime(2023, 5, 11) },
                new Assessment() { AssessmentId = 6, AssessmentName = "Drawing Project", SubjectId = 106, DueDate = new DateTime(2023, 5, 15) },
                new Assessment() { AssessmentId = 7, AssessmentName = "Practical Project", SubjectId = 107, DueDate = new DateTime(2023, 5, 20) },
                new Assessment() { AssessmentId = 8, AssessmentName = "Physics Experiment", SubjectId = 108, DueDate = new DateTime(2023, 5, 20) },
                new Assessment() { AssessmentId = 9, AssessmentName = "Chemistry Experiment", SubjectId = 109, DueDate = new DateTime(2023, 5, 25) },
                new Assessment() { AssessmentId = 10, AssessmentName = "Physical Exam", SubjectId = 110, DueDate = new DateTime(2023, 5, 28) },
                new Assessment() { AssessmentId = 11, AssessmentName = "Maths Exam", SubjectId = 101, DueDate = new DateTime(2023, 5, 30) },
                new Assessment() { AssessmentId = 12, AssessmentName = "Biology Exam", SubjectId = 102, DueDate = new DateTime(2023, 5, 31) },
                new Assessment() { AssessmentId = 13, AssessmentName = "History Exam", SubjectId = 103, DueDate = new DateTime(2023, 6, 01) },
                new Assessment() { AssessmentId = 14, AssessmentName = "English Exam", SubjectId = 104, DueDate = new DateTime(2023, 6, 05) },
                new Assessment() { AssessmentId = 15, AssessmentName = "Coding Exam", SubjectId = 105, DueDate = new DateTime(2023, 6, 10) },
                new Assessment() { AssessmentId = 16, AssessmentName = "Art Exam", SubjectId = 106, DueDate = new DateTime(2023, 6, 12) },
                new Assessment() { AssessmentId = 17, AssessmentName = "Theory Exam", SubjectId = 107, DueDate = new DateTime(2023, 6, 15) },
                new Assessment() { AssessmentId = 18, AssessmentName = "Physics Exam", SubjectId = 108, DueDate = new DateTime(2023, 6, 15) },
                new Assessment() { AssessmentId = 19, AssessmentName = "Chemistry Exam", SubjectId = 109, DueDate = new DateTime(2023, 6, 18) },
                new Assessment() { AssessmentId = 20, AssessmentName = "Physical Education Exam", SubjectId = 110, DueDate = new DateTime(2023, 6, 20) },
                new Assessment() { AssessmentId = 21, AssessmentName = "Test 1", SubjectId = 101, DueDate = new DateTime(2023, 5, 22) },
                new Assessment() { AssessmentId = 22, AssessmentName = "Test 2", SubjectId = 101, DueDate = new DateTime(2023, 5, 27) },
                new Assessment() { AssessmentId = 23, AssessmentName = "Solo Project 2", SubjectId = 105, DueDate = new DateTime(2023, 6, 8) },
                new Assessment() { AssessmentId = 24, AssessmentName = "Group Project 1", SubjectId = 105, DueDate = new DateTime(2023, 6, 25) },
                new Assessment() { AssessmentId = 25, AssessmentName = "Group Project 2", SubjectId = 105, DueDate = new DateTime(2023, 5, 30) }
            );

            // Marks 
            context.Marks.AddOrUpdate(m => m.MarkId,

                new Mark() { MarkId = 1, AssessmentId = 1, LearnerId = 1, MarkObtained = 38, Comment = "Need improvement." },
                new Mark() { MarkId = 2, AssessmentId = 2, LearnerId = 2, MarkObtained = 76, Comment = "Good effort!" },
                new Mark() { MarkId = 3, AssessmentId = 3, LearnerId = 3, MarkObtained = 62, Comment = "Well done! Keep it up." },
                new Mark() { MarkId = 4, AssessmentId = 4, LearnerId = 4, MarkObtained = 84, Comment = "Excellent research!" },
                new Mark() { MarkId = 5, AssessmentId = 5, LearnerId = 1, MarkObtained = 90, Comment = "Impressive analysis!" },
                new Mark() { MarkId = 6, AssessmentId = 6, LearnerId = 1, MarkObtained = 88, Comment = "Very well done! Strong performance." },
                new Mark() { MarkId = 7, AssessmentId = 7, LearnerId = 2, MarkObtained = 50, Comment = "Average performance. Consider improvement." },
                new Mark() { MarkId = 8, AssessmentId = 8, LearnerId = 3, MarkObtained = 41, Comment = "Below average. Focus on improvement areas." },
                new Mark() { MarkId = 9, AssessmentId = 9, LearnerId = 4, MarkObtained = 82, Comment = "Excellent research!" },
                new Mark() { MarkId = 10, AssessmentId = 10, LearnerId = 1, MarkObtained = 58, Comment = "Good effort. Consider refining analysis skills." }
            );

            // Guardian 
            context.Guardians.AddOrUpdate(g => g.GuardianId,
                new Guardian() { GuardianId = 1, FirstName = "Michael", LastName = "Williams", Relationship = "Parent", Contact = "123-456-7890", AddressId = 2 },
                new Guardian() { GuardianId = 2, FirstName = "Sophia", LastName = "Johnson", Relationship = "Parent", Contact = "334-446-7770", AddressId = 8 },
                new Guardian() { GuardianId = 3, FirstName = "Emily", LastName = "Smith", Relationship = "Parent", Contact = "223-456-0110", AddressId = 9 },
                new Guardian() { GuardianId = 4, FirstName = "Daniel", LastName = "Brown", Relationship = "Parent", Contact = "222-444-7890", AddressId = 4 },
                new Guardian() { GuardianId = 5, FirstName = "Olivia", LastName = "Davis", Relationship = "Parent", Contact = "333-555-7809", AddressId = 5 },
                new Guardian() { GuardianId = 6, FirstName = "James", LastName = "Wilson", Relationship = "Parent", Contact = "111-456-7811", AddressId = 10 },
                new Guardian() { GuardianId = 7, FirstName = "Ava", LastName = "Martinez", Relationship = "Parent", Contact = "123-111-1144", AddressId = 7 },
                new Guardian() { GuardianId = 8, FirstName = "Logan", LastName = "Garcia", Relationship = "Parent", Contact = "110-99-9833", AddressId = 1 },
                new Guardian() { GuardianId = 9, FirstName = "Mia", LastName = "Lopez", Relationship = "Parent", Contact = "123-321-4567", AddressId = 3 },
                new Guardian() { GuardianId = 10, FirstName = "Ethan", LastName = "Lee", Relationship = "Parent", Contact = "110-234-4345", AddressId = 6 }
            );



            // Subject 
            context.Subjects.AddOrUpdate(s => s.SubjectId,
                new Subject() { SubjectId = 101, SubjectName = "Mathematics", SubjectCode = "MATH101", SubjectDescription = "Intro to Mathematics" },
                new Subject() { SubjectId = 102, SubjectName = "Biology", SubjectCode = "BIO102", SubjectDescription = "General Science" },
                new Subject() { SubjectId = 103, SubjectName = "History", SubjectCode = "HIST103", SubjectDescription = "World History" },
                new Subject() { SubjectId = 104, SubjectName = "English", SubjectCode = "ENGL104", SubjectDescription = "English Literature" },

                new Subject() { SubjectId = 105, SubjectName = "Computer Science", SubjectCode = "CS105", SubjectDescription = "Introduction to Programming" },
                new Subject() { SubjectId = 106, SubjectName = "Art", SubjectCode = "ART106", SubjectDescription = "Visual Arts" },
                new Subject() { SubjectId = 107, SubjectName = "Music", SubjectCode = "MUS107", SubjectDescription = "Music Appreciation" },
                new Subject() { SubjectId = 108, SubjectName = "Physics", SubjectCode = "PHY108", SubjectDescription = "Advanced Physics" },
                new Subject() { SubjectId = 109, SubjectName = "Chemistry", SubjectCode = "CHEM109", SubjectDescription = "Chemical Reactions" },
                new Subject() { SubjectId = 110, SubjectName = "Physical Education", SubjectCode = "PED110", SubjectDescription = "Health and Fitness" }
            );


            // TeacherSubject
            context.TeacherSubjects.AddOrUpdate(ts => ts.TeacherSubjectId,
                new TeacherSubject() { TeacherSubjectId = 1, TeacherId = 1, SubjectId = 101 },
                new TeacherSubject() { TeacherSubjectId = 2, TeacherId = 1, SubjectId = 102 },
                new TeacherSubject() { TeacherSubjectId = 3, TeacherId = 2, SubjectId = 102 },
                new TeacherSubject() { TeacherSubjectId = 4, TeacherId = 2, SubjectId = 103 },
                new TeacherSubject() { TeacherSubjectId = 5, TeacherId = 3, SubjectId = 101 },
                new TeacherSubject() { TeacherSubjectId = 6, TeacherId = 4, SubjectId = 104 },
                new TeacherSubject() { TeacherSubjectId = 7, TeacherId = 4, SubjectId = 105 },
                new TeacherSubject() { TeacherSubjectId = 8, TeacherId = 5, SubjectId = 105 },
                new TeacherSubject() { TeacherSubjectId = 9, TeacherId = 5, SubjectId = 106 },
                new TeacherSubject() { TeacherSubjectId = 10, TeacherId = 4, SubjectId = 104 },
                new TeacherSubject() { TeacherSubjectId = 11, TeacherId = 6, SubjectId = 109 },
                new TeacherSubject() { TeacherSubjectId = 12, TeacherId = 7, SubjectId = 110 },
                new TeacherSubject() { TeacherSubjectId = 13, TeacherId = 9, SubjectId = 110 },
                new TeacherSubject() { TeacherSubjectId = 14, TeacherId = 10, SubjectId = 105 },
                new TeacherSubject() { TeacherSubjectId = 15, TeacherId = 10, SubjectId = 107 }
            );
        }
    }
}
