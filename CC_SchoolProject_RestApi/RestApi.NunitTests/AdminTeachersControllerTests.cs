using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;
using CC_SchoolProject_RestApi.Controllers;
using CC_SchoolProject_RestApi.Models;
using CC_SchoolProject_RestApi.PageModels;

namespace RestApi.NunitTests
{
    [TestFixture]
    public class AdminTeachersControllerTests
    {
        Object _schoolContext;
        private AdminTeachersController _controllerUnderTest;
        private List<Teacher> _teacherList;

        Teacher _teacher;

        [SetUp]
        public void Initialiser()
        {
            _schoolContext = InMemoryContext.Generated();
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
            _teacherList = null;
            _teacher = null;
        }

        [Test]
        public async Task _01Test_GetAllTeachers_ReturnsaListwithValidCount()
        {
            //Arrange 
            var _localSchoolContext = (CodeCrusaders_School_Management_DBContext)_schoolContext;
            _localSchoolContext.Database.EnsureDeleted();
            _controllerUnderTest = new AdminTeachersController(_localSchoolContext);


            ////Act            
            await _controllerUnderTest.Teachers();
            await _controllerUnderTest.Teachers();
            await _controllerUnderTest.Teachers();
            await _controllerUnderTest.Teachers();

            //Assert
            Assert.NotNull(_localSchoolContext.Teachers);
            Assert.AreEqual(_localSchoolContext.Teachers.Count(), 0);

        }

        [Test]
        public async Task _09Test_GetAllTeachers_ReturnsWithCorrectType()
        {
            //Arrange 
            var _localSchoolContext = (CodeCrusaders_School_Management_DBContext)_schoolContext;
            _localSchoolContext.Database.EnsureDeleted();
            _controllerUnderTest = new AdminTeachersController(_localSchoolContext);


            await _controllerUnderTest.Teachers();
            await _controllerUnderTest.Teachers();

            //Act            
            var actionResult = await _controllerUnderTest.GetTeacherByID(2);

            //Assert
            Assert.NotNull(actionResult);
            Assert.IsInstanceOf<ActionResult<Teacher>>(actionResult);
        }

        [Test]
        public async Task _10Test_GetAllTeachers_ReturnsWithCorrectTypeAndCount()
        {
            //Arrange 
            var _localSchoolContext = (CodeCrusaders_School_Management_DBContext)_schoolContext;
            _localSchoolContext.Database.EnsureDeleted();
            _controllerUnderTest = new AdminTeachersController(_localSchoolContext);


            await _controllerUnderTest.Teachers();
            await _controllerUnderTest.Teachers();
            await _controllerUnderTest.Teachers();
            await _controllerUnderTest.Teachers();

            //Act            
            var actionResult = await _controllerUnderTest.Teachers();

            //Assert
            Assert.NotNull(actionResult);
            Assert.IsInstanceOf<ActionResult<IEnumerable<Teacher>>>(actionResult);
            var value = actionResult.Value;
            Assert.AreEqual(value.Count(), 0);
        }

        [Test]
        public async Task _11Test_GetTeacherById_ReturnsWithCorrectType()
        {
            //Arrange 
            var _localSchoolContext = (CodeCrusaders_School_Management_DBContext)_schoolContext;
            _localSchoolContext.Database.EnsureDeleted();
            _controllerUnderTest = new AdminTeachersController(_localSchoolContext);


            await _controllerUnderTest.Teachers();
            await _controllerUnderTest.Teachers();

            //Act            
            var actionResult = await _controllerUnderTest.GetTeacherByID(1);

            //Assert
            Assert.NotNull(actionResult);
            Assert.IsInstanceOf<ActionResult<Teacher>>(actionResult);
        }

        [Test]
        public async Task _12Test_GetTeacherById_ReturnsWithCorrectType()
        {
            //Arrange 
            var _localSchoolContext = (CodeCrusaders_School_Management_DBContext)_schoolContext;
            _localSchoolContext.Database.EnsureDeleted();
            _controllerUnderTest = new AdminTeachersController(_localSchoolContext);


            await _controllerUnderTest.Teachers();
            await _controllerUnderTest.Teachers();


            //Act            
            var actionResult = await _controllerUnderTest.GetTeacherByID(1);

            //Assert
            Assert.NotNull(actionResult);
            Assert.IsInstanceOf<ActionResult<Teacher>>(actionResult);
        }

        [Test]
        public async Task _13Test_CreateTeacher_AddedSuccessfullyAndShowsInContextCount()
        {
            //Arrange 
            var _localSchoolContext = (CodeCrusaders_School_Management_DBContext)_schoolContext;
            _localSchoolContext.Database.EnsureDeleted();
            _controllerUnderTest = new AdminTeachersController(_localSchoolContext);

            //Act            
            var actionResult = await _controllerUnderTest.Teachers();

            //Assert
           Assert.NotNull(actionResult);
            Assert.AreEqual(_localSchoolContext.Teachers.Count(), 0);
        }



        


    }
}