using CC_SchoolProject_RestApi.Models;
using CC_SchoolProject_RestApi.PageModels;
using CC_SchoolProject_RestApi.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.NunitTests
{
    public class PrincipalRepoTests
    {
        private Mock<CodeCrusaders_School_Management_DBContext> _mockContext;
        private Mock<PrincipalRepo> _mockPrincipalRepo;



        [SetUp]
        public void Initialiser()
        {
            _mockContext = new Mock<CodeCrusaders_School_Management_DBContext>();
            _mockPrincipalRepo= new Mock<PrincipalRepo>(_mockContext.Object);

        }

        [TearDown]
        public void CleanUp() {
            _mockContext = null;
            _mockPrincipalRepo = null;
        
        }

        // Get Teacher by Status (Active or Non Active)

        [TestCase("Active")]
        [TestCase("Not Active")]
        public void _01_Test_GetAllTeacherByStatus_ReturnsTeachersByStatus(string status)
        {
            // arrange
            string activeStatus = "Active";
            string notActiveStatus = "Not Active";
            var teachers = new List<Teacher> {
                new Teacher{ TeacherId = 1, FirstName="John", LastName="Deed", DateOfBirth= new DateTime(1997,01,03), ContactNumber="1230344044", EmailAddress="Deed@gmail.com", AddressId=1, Username="John.Deed", StartDate= new DateTime(2023,03,01), Status="Active"},
                new Teacher{ TeacherId = 2, FirstName="Sam", LastName="Moore", DateOfBirth= new DateTime(1995,01,06), ContactNumber="12223344044", EmailAddress="Sam@gmail.com", AddressId=2, Username="Sam.Moore", StartDate= new DateTime(2024,05,01), Status="Active"},
                new Teacher{ TeacherId = 3, FirstName="Sarah", LastName="Moore", DateOfBirth= new DateTime(1998,03,03), ContactNumber="1999344044", EmailAddress="Sarah@gmail.com", AddressId=3, Username="Sarah123", StartDate= new DateTime(2023,05,01), Status="Not Active"},
                new Teacher{ TeacherId = 4, FirstName="Terry", LastName="Sour", DateOfBirth= new DateTime(1999,03,03), ContactNumber="1995787387", EmailAddress="Terry@gmail.com", AddressId=3, Username="Terry123", StartDate= new DateTime(2023,06,01), Status="Not Active"}
            };

            var teachersByStatus = teachers.Where(t => t.Status == status).ToList();
            _mockPrincipalRepo.Setup(x => x.GetAllTeacherByStatus(status)).Returns(teachersByStatus);


            // act
            var result = _mockPrincipalRepo.Object.GetAllTeacherByStatus(status);


            // assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.IsTrue(result.All(t => t.Status == status));
        }

        // get all learners

        [Test]
        public void _02_Test_GetLearnerList_ReturnAllLearners()
        {
            // arrange
            var learners = new List<Learner>
            {
                new Learner { LearnerId =1,FirstName="John", LastName="Deed",StartDate= new DateTime(2023,01,08), DateOfBirth= new DateTime(2005,01,03), GuardianId = 1},
                new Learner { LearnerId =2,FirstName="Sonny", LastName="Tomas",StartDate= new DateTime(2023,01,08), DateOfBirth= new DateTime(2006,01,04), GuardianId = 2},
                new Learner { LearnerId =3,FirstName="Wayne", LastName="Reek",StartDate= new DateTime(2023,01,08), DateOfBirth= new DateTime(2005,02,04), GuardianId = 2}
            };

            _mockPrincipalRepo.Setup(x => x.GetLearnerList()).Returns(learners);

            // act
            var result = _mockPrincipalRepo.Object.GetLearnerList();


            // assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(learners.Count));

        }

        
        // Get a detailed list of all the learner with the guardian information and the adddress
        [Test]
        public void _03_Test_GetLearnerInformation_ReturnAllLearnersWithDetailedInformation()
        {
            // arrange
            var learners = new List<LearnerInfoReport>
            {
                new LearnerInfoReport { FirstName="John", LastName="Deed", GuardianFirstName = "Frank", GuardianLastName= "Deed" , Relationship="Father", Contact="1221323", AddressLine="123 Rod Str ", Suburb="Point", PostalCode="12332"},
                new LearnerInfoReport { FirstName="Hanny", LastName="Tomas", GuardianFirstName = "Sarah", GuardianLastName= "Tomas" , Relationship="Sister", Contact="3454545", AddressLine="123 Road Str ", Suburb="South", PostalCode="87865"},
                new LearnerInfoReport { FirstName="Roos", LastName="Johnson", GuardianFirstName = "Marry", GuardianLastName= "Johnson" , Relationship="Mother", Contact="876324", AddressLine="3243 PointCase Str ", Suburb="RedSouth", PostalCode="43545"}
            };

            _mockPrincipalRepo.Setup(x => x.GetLearnerInformation()).Returns(learners);

            // act
            var result = _mockPrincipalRepo.Object.GetLearnerInformation();


            // assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(learners.Count));

        }


        // Get a list of all the teacher with the subject that they teach
        [Test]
        public void _04_Test_GetTeacherSubjectInfo_ReturnAllTeachersAndSubjectTheyTeach()
        {
            // arrange
            var teacherSubject = new List<TeacherSubjectReport>
            {
                new TeacherSubjectReport { FirstName="John", LastName="Doe",  Status = "Active",SubjectName = "Math",SubjectCode = "MATH101",SubjectDescription = "Introduction to Mathematics"},
                new TeacherSubjectReport { FirstName="Jane", LastName="Smith",  Status = "Not Active",SubjectName = "Science",SubjectCode = "SCI201",SubjectDescription = "Introduction to Science"},
            };

            _mockPrincipalRepo.Setup(x => x.GetTeacherSubjectInfo()).Returns(teacherSubject);

            // act
            var result = _mockPrincipalRepo.Object.GetTeacherSubjectInfo();


            // assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(teacherSubject.Count));

        }

        [Test]
        public void _05_Test_GetLearnerSubjectInfo_ReturnAllTeachersAndSubjectTheyTeach()
        {
            // arrange
            var learnerSubject = new List<LearnerSubjectReport>
{
                new LearnerSubjectReport { FirstName = "Alice", LastName = "Johnson", SubjectName = "Math", SubjectDescription = "Algebra" },
                new LearnerSubjectReport { FirstName = "Bob", LastName = "Smith", SubjectName = "Science", SubjectDescription = "Biology" },
                new LearnerSubjectReport { FirstName = "Charlie", LastName = "Brown", SubjectName = "English", SubjectDescription = "Literature" }
                
            };

            _mockPrincipalRepo.Setup(x => x.GetLearnerSubjectInfo()).Returns(learnerSubject);

            // act
            var result = _mockPrincipalRepo.Object.GetLearnerSubjectInfo();


            // assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(learnerSubject.Count));

        }

        
        [Test]
        public void _06_Test_GetLearnerAssessmentInfo_ReturnAllLearnersSubjectAndAssesmentMark()
        {
            // arrange
            var learnerAssessments = new List<LearnerAssessmentsReport>
            {
                new LearnerAssessmentsReport { FirstName = "Alice", LastName = "Johnson", SubjectName = "Math", AssessmentName = "Midterm Exam", MarkObtained = 85, Comment = "Good performance" },
                new LearnerAssessmentsReport { FirstName = "Bob", LastName = "Smith", SubjectName = "Science", AssessmentName = "Final Exam", MarkObtained = 92, Comment = "Excellent work" },
                
            };

            _mockPrincipalRepo.Setup(x => x.GetLearnerAssessmentInfo()).Returns(learnerAssessments);

            // act
            var result = _mockPrincipalRepo.Object.GetLearnerAssessmentInfo();


            // assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(learnerAssessments.Count));

        }


    }
}
