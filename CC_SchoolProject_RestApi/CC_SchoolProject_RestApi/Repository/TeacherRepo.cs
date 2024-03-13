using CC_SchoolProject_RestApi.Models;
using CC_SchoolProject_RestApi.PageModels;
using System.Net.Mail;

namespace CC_SchoolProject_RestApi.Repositories
{
    public class TeacherRepo
    {
        private readonly CodeCrusaders_School_Management_DBContext _context;

        public TeacherRepo(CodeCrusaders_School_Management_DBContext context)
        {
            _context = context;
        }

        public virtual List<Teacher> GetAllTeachers()
        {
            List<Teacher> allTeachers = _context.Teachers.ToList();

            return allTeachers;
        }
        public virtual Teacher GetTeacherWithId(int id)
        {
            var teacher = _context.Teachers.Find(id);

            return teacher;
        }

        
        public void CreateNewTeacher(TeacherAddressVM teacherVM)
        {
            // Address
            var address = new Address
            {
                AddressLine = teacherVM.AddressLine,
                Suburb = teacherVM.Suburb,
                PostalCode = teacherVM.PostalCode
            };

            _context.Set<Address>().Add(address);
            _context.SaveChanges();
            var addressId = address.AddressId;

            

            // Teacher
            var teacher = new Teacher
            {
                AddressId = addressId,
                FirstName = teacherVM.FirstName,
                LastName = teacherVM.LastName,
                StartDate = teacherVM.StartDate,
                DateOfBirth = teacherVM.DateOfBirth,
                Status = teacherVM.Status,
                EmailAddress= teacherVM.EmailAddress,
                ContactNumber= teacherVM.ContactNumber,
                Username=teacherVM.Username
                

            };

            _context.Set<Teacher>().Add(teacher);
            _context.SaveChanges();
        }

    }
}
