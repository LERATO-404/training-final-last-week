
using Moq;
using CC_SchoolProject_RestApi.Models;
using CC_SchoolProject_RestApi.Repositories;
using CC_SchoolProject_RestApi.PageModels;
using System.Net.Mail;

namespace RestApi.NunitTests
{
    [TestFixture]
    public class AdminTeacherControllerTests
    {
        private Mock<CodeCrusaders_School_Management_DBContext> _mockContext;
        private Mock<TeacherRepo> _mockTeacherRepo;

        private List<Teacher> _teacherList;
        private Teacher _teacher;

        

        [SetUp]
        public void Initialiser()
        {
            _mockContext = new Mock<CodeCrusaders_School_Management_DBContext>();
            _mockTeacherRepo = new Mock<TeacherRepo>(_mockContext.Object);
            _teacherList = new List<Teacher>();
            _teacher = new Teacher()
            {
                TeacherId = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1985 - 05 - 15),
                ContactNumber = "083 - 456 - 7890",
                EmailAddress = "john.doe@example.com",
                AddressId = 1,
                Username = "johndoe",
                StartDate = new DateTime(2020 - 09 - 01),
                Status = "Active"
            };

            
        }

        [TearDown]
        public void Cleanup()
        {
            _mockContext = null;
            _mockTeacherRepo = null;
            _teacherList = null;
            _teacher = null;
            
        }

        [Test]
        public void _01Test_GetAllTeachers_IsCalledOnce()
        {
            //Act
            _teacherList = _mockTeacherRepo.Object.GetAllTeachers();

            _mockTeacherRepo.Verify(n => n.GetAllTeachers(), Times.Once);
        }

        [Test]
        public void _02Test_GetAllTeachers_ReturnsEmptyList()
        {
            //Arrange
            _mockTeacherRepo.Setup(n => n.GetAllTeachers()).Returns(_teacherList);
            //Act
            var actual = _mockTeacherRepo.Object.GetAllTeachers();
            var expected = _teacherList;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _03Test_GetAllTeachers_ReturnsListOf3_WhenCalledWith3Entries()
        {
            _teacherList.Add(_teacher);
            _teacherList.Add(_teacher);
            _teacherList.Add(_teacher);
            _mockTeacherRepo.Setup(n => n.GetAllTeachers()).Returns(_teacherList);

            var actual = _mockTeacherRepo.Object.GetAllTeachers();
            var expected = _teacherList;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _04Test_GetTeacherWithId_IsCalledOnce()
        {
            int id = _teacher.TeacherId;

            _teacher = _mockTeacherRepo.Object.GetTeacherWithId(id);

            _mockTeacherRepo.Verify(n => n.GetTeacherWithId(id), Times.Once);
        }

        [Test]
        public void _05Test_GetTeacherWithId_ReturnsAValidCustomer_WhenCalledWithId1()
        {
            int id = _teacher.TeacherId;
            _mockTeacherRepo.Setup(n => n.GetTeacherWithId(id)).Returns(_teacher);

            var actual = _mockTeacherRepo.Object.GetTeacherWithId(id);
            var expected = _teacher;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void _06Test_GetTeacher_IsCalledOnce()
        {
            _teacherList = _mockTeacherRepo.Object.GetAllTeachers();

            _mockTeacherRepo.Verify(n => n.GetAllTeachers(), Times.Once);
        }

        [Test]
        public void _07Test_GetAllTeachers_ReturnsListOf3_WhenCalledWith3Entries()
        {
            _teacherList.Add(_teacher);
            _teacherList.Add(_teacher);
            _teacherList.Add(_teacher);
            _mockTeacherRepo.Setup(n => n.GetAllTeachers()).Returns(_teacherList);

            var actual = _mockTeacherRepo.Object.GetAllTeachers();
            var expected = _teacherList;

            Assert.AreEqual(expected, actual);
        }



        [Test]
        public void _08Test_GetAllTeachers_IsCalledOnce()
        {
            _mockContext = new Mock<CodeCrusaders_School_Management_DBContext>();
            _mockTeacherRepo = new Mock<TeacherRepo>(_mockContext.Object);
            _teacherList = new List<Teacher>();
            _teacher = new Teacher()
            {
                TeacherId = 10,
                FirstName = "Sam",
                LastName = "Smith",
                DateOfBirth = new DateTime(1988 - 11 - 11),
                ContactNumber = "082 -333- 3987",
                EmailAddress = "sam.smith@example.com",
                AddressId = 10,
                Username = "samsmith",
                StartDate = new DateTime(2018 - 06 - 12),
                Status = "Active"
            };
        }

            [Test]
            public void _09Test_GetAllTeachers_ReturnsEmptyList()
            {
                //Arrange
                _mockTeacherRepo.Setup(n => n.GetAllTeachers()).Returns(_teacherList);
                //Act
                var actual = _mockTeacherRepo.Object.GetAllTeachers();
                var expected = _teacherList;
                //Assert
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void _10Test_GetAllTeachers_ReturnsListOf3_WhenCalledWith3Entries()
            {
                _teacherList.Add(_teacher);
                _teacherList.Add(_teacher);
                _teacherList.Add(_teacher);
                _mockTeacherRepo.Setup(n => n.GetAllTeachers()).Returns(_teacherList);

                var actual = _mockTeacherRepo.Object.GetAllTeachers();
                var expected = _teacherList;

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void _11Test_GetTeacherWithId_IsCalledOnce()
            {
                int id = _teacher.TeacherId;

                _teacher = _mockTeacherRepo.Object.GetTeacherWithId(id);

                _mockTeacherRepo.Verify(n => n.GetTeacherWithId(id), Times.Once);
            }

            [Test]
            public void _12Test_GetTeacherWithId_ReturnsAValidCustomer_WhenCalledWithId1()
            {
                int id = _teacher.TeacherId;
                _mockTeacherRepo.Setup(n => n.GetTeacherWithId(id)).Returns(_teacher);

                var actual = _mockTeacherRepo.Object.GetTeacherWithId(id);
                var expected = _teacher;

                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void _13Test_GetTeacher_IsCalledOnce()
            {
                _teacherList = _mockTeacherRepo.Object.GetAllTeachers();

                _mockTeacherRepo.Verify(n => n.GetAllTeachers(), Times.Once);
            }

            [Test]
            public void _14Test_GetAllTeacherd_ReturnsListOf3_WhenCalledWith3Entries()
            {
                _teacherList.Add(_teacher);
                _teacherList.Add(_teacher);
                _teacherList.Add(_teacher);
                _mockTeacherRepo.Setup(n => n.GetAllTeachers()).Returns(_teacherList);

                var actual = _mockTeacherRepo.Object.GetAllTeachers();
                var expected = _teacherList;

                Assert.AreEqual(expected, actual);
            }






        


    }
}
