using System.Security.Policy;
using CC_SchoolProject_RestApi.Models;
using CC_SchoolProject_RestApi.PageModels;

namespace CC_SchoolProject_RestApi.Repository
{
    public class PrincipalRepo
    {
        private readonly CodeCrusaders_School_Management_DBContext _schoolContext;

        public PrincipalRepo(CodeCrusaders_School_Management_DBContext context)
        {
            _schoolContext = context;
        }

        // Add a new teacher
        public virtual Teacher CreateNewTeacher(TeacherRegister teacher)
        {
            DateTime currentDate = DateTime.Now;
            DateTime nextMonday = currentDate;

            while (nextMonday.DayOfWeek != DayOfWeek.Monday)
            {
                nextMonday = nextMonday.AddDays(1);
            }

            var newTeacher = new Teacher()
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                DateOfBirth = teacher.DateOfBirth,
                ContactNumber = teacher.ContactNumber,
                EmailAddress = teacher.EmailAddress,
                Username = teacher.Username,
                StartDate = nextMonday,
                Status = "Not Active",
            };

            _schoolContext.Teachers.Add(newTeacher);
            _schoolContext.SaveChanges();
            return newTeacher;
        }

        // get all learners
        public virtual List<Learner> GetLearnerList()
        {
            return _schoolContext.Learners.ToList();
        }

        // Get Teacher by Status (Active or Non Active)
        public virtual List<Teacher> GetAllTeacherByStatus(string status)
        {
            var lowercaseStatus = status.ToLower();

            var allTeachersByStatus = _schoolContext.Teachers
                    .Where(d => d.Status.ToLower() == lowercaseStatus)
                    .ToList();

            return allTeachersByStatus;
        }

        // Get a detailed list of all the learner with the guardian information and the adddress
        public virtual List<LearnerInfoReport> GetLearnerInformation()
        {
            List<LearnerInfoReport> allLearners = new List<LearnerInfoReport>();

            var detailedLearnerList =
                (from Learner in _schoolContext.Learners
                 join Guardian in _schoolContext.Guardians
                 on Learner.GuardianId equals Guardian.GuardianId
                 join Address in _schoolContext.Addresses
                 on Guardian.AddressId equals Address.AddressId
                 orderby Learner.LearnerId
                 select new
                 {

                     LearnerFirstName = Learner.FirstName,
                     LearnerLastName = Learner.LastName,


                     GuardianFirstName = Guardian.FirstName,
                     GuardianLastName = Guardian.LastName,
                     Relationship = Guardian.Relationship,
                     Contact = Guardian.Contact,


                     AddressLine = Address.AddressLine,
                     Suburb = Address.Suburb,
                     PostalCode = Address.PostalCode,

                 }
                 ).ToList();


            foreach (var learnerInfo in detailedLearnerList)
            {
                allLearners.Add(new LearnerInfoReport()
                {

                    FirstName = learnerInfo.LearnerFirstName,
                    LastName = learnerInfo.LearnerLastName,


                    GuardianFirstName = learnerInfo.GuardianFirstName,
                    GuardianLastName = learnerInfo.GuardianLastName,
                    Relationship = learnerInfo.Relationship,
                    Contact = learnerInfo.Contact,


                    AddressLine = learnerInfo.AddressLine,
                    Suburb = learnerInfo.Suburb,
                    PostalCode = learnerInfo?.PostalCode

                });
            }

            return allLearners;
        }



        // Get a list of all the teacher with the subject that they teach
        public virtual List<TeacherSubjectReport> GetTeacherSubjectInfo()
        {
            List<TeacherSubjectReport> allTeacherSubject = new List<TeacherSubjectReport>();


            var teacherSubjectList =
                (
                from TeacherSubject in _schoolContext.TeacherSubjects
                join Teachers in _schoolContext.Teachers
                on TeacherSubject.TeacherId equals Teachers.TeacherId
                join Subjects in _schoolContext.Subjects
                on TeacherSubject.SubjectId equals Subjects.SubjectId
                orderby Teachers.TeacherId
                select new
                {

                    TeacherFirstName = Teachers.FirstName,
                    TeacherLastName = Teachers.LastName,
                    TeacherStatus = Teachers.Status,


                    SubjectName = Subjects.SubjectName,
                    SubjectCode = Subjects.SubjectCode,
                    SubjectDescription = Subjects.SubjectDescription,



                }).ToList();

            foreach (var teacherInfo in teacherSubjectList)
            {
                allTeacherSubject.Add(new TeacherSubjectReport()
                {

                    FirstName = teacherInfo.TeacherFirstName,
                    LastName = teacherInfo.TeacherLastName,
                    Status = teacherInfo.TeacherStatus,

                    SubjectName = teacherInfo?.SubjectName,
                    SubjectCode = teacherInfo?.SubjectCode,
                    SubjectDescription = teacherInfo?.SubjectDescription


                });
            }

            return allTeacherSubject;

        }


        // Get all learners by subject
        public virtual List<LearnerSubjectReport> GetLearnerSubjectInfo()
        {
            List<LearnerSubjectReport> allLearnerSubject = new List<LearnerSubjectReport>();

            var learnerSubjectList =
               (
               from Mark in _schoolContext.Marks
               join Learner in _schoolContext.Learners
               on Mark.LearnerId equals Learner.LearnerId
               join Assessment in _schoolContext.Assessments
               on Mark.AssessmentId equals Assessment.AssessmentId
               join Subjects in _schoolContext.Subjects
               on Assessment.SubjectId equals Subjects.SubjectId
               orderby Learner.LearnerId
               select new
               {
                   LearnerFirstName = Learner.FirstName,
                   LearnerLastName = Learner.LastName,
                   SubjectName = Subjects.SubjectName,
                   SubjectDescription = Subjects.SubjectDescription
               }).ToList();


            foreach (var leanerInfo in learnerSubjectList)
            {
                allLearnerSubject.Add(new LearnerSubjectReport()
                {
                    FirstName = leanerInfo.LearnerFirstName,
                    LastName = leanerInfo.LearnerLastName,
                    SubjectName = leanerInfo.SubjectName,
                    SubjectDescription = leanerInfo.SubjectDescription
                });
            }

            return allLearnerSubject;
        }

        // Get one learner with the all assessment and mark the learner obtained
        public virtual List<LearnerAssessmentsReport> GetLearnerAssessmentInfo()
        {
            List<LearnerAssessmentsReport> allLearnerAssessment = new List<LearnerAssessmentsReport>();

            var learnerAssessmentList =
               (
               from Mark in _schoolContext.Marks
               join Learner in _schoolContext.Learners
               on Mark.LearnerId equals Learner.LearnerId
               join Assessment in _schoolContext.Assessments
               on Mark.AssessmentId equals Assessment.AssessmentId
               join Subject in _schoolContext.Subjects
               on Assessment.AssessmentId equals Subject.SubjectId
               orderby Learner.LearnerId
               select new
               {
                   LearnerFirstName = Learner.FirstName,
                   LearnerLastName = Learner.LastName,

                   Subject = Subject.SubjectName,

                   AssessmentName = Assessment.AssessmentName,

                   MarkObtained = Mark.MarkObtained,
                   Comment = Mark.Comment,
               }).ToList();

            foreach (var learnerAssessment in learnerAssessmentList)
            {
                allLearnerAssessment.Add(new LearnerAssessmentsReport()
                {
                    FirstName = learnerAssessment.LearnerFirstName,
                    LastName = learnerAssessment.LearnerLastName,

                    SubjectName = learnerAssessment.Subject,

                    AssessmentName = learnerAssessment.AssessmentName,

                    MarkObtained = learnerAssessment.MarkObtained,
                    Comment = learnerAssessment.Comment
                });
            }

            return allLearnerAssessment;
        }
    }
}
