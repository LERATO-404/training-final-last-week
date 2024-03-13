using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Resource;
using CC_SchoolProject_RestApi.Models;
using CC_SchoolProject_RestApi.Repositories;
using Moq;

namespace RestApi.NunitTests
{
    [TestFixture]
    public class AdminLearnersRepoTests
    {
        private Mock<CodeCrusaders_School_Management_DBContext> _mockContext;
        private Mock<AdminLearnersRepo> _mockLearnerRepo;

        private List<Learner> _learnersList;
        private Learner _learner;


        [SetUp]
        public void Initialiser()
        {
            _mockContext = new Mock<CodeCrusaders_School_Management_DBContext>();
            _mockLearnerRepo = new Mock<AdminLearnersRepo>(_mockContext.Object);
            _learnersList = new List<Learner>();
            _learner = new Learner()
            {
                LearnerId = 1,
                FirstName = "Sam",
                LastName = "Williams",
                StartDate = new DateTime(2018, 01, 11, 00, 00, 00, 000),
                DateOfBirth = new DateTime(2005, 04, 08, 00, 00, 00, 000),
                GuardianId = 1
            };

            _learnersList = new List<Learner>();
            _learner = new Learner()
            {

                LearnerId = 2,
                FirstName = "Olivia",
                LastName = "Johnson",
                StartDate = new DateTime(2021, 02, 15, 00, 00, 00, 000),
                DateOfBirth = new DateTime(2008, 07, 12, 00, 00, 00, 000),
                GuardianId = 2
            };
        }

        [TearDown]
        public void Cleanup()
        {
            _mockContext = null;
            _mockLearnerRepo = null;
            _learnersList = null;
            _learner = null;
            //_customerBookingList = null;
            //_customerBooking = null;
        }

        [Test]
        public void _01Test_GetAllLearners_IsCalledOnce()
        {
            //Act
            _learnersList = _mockLearnerRepo.Object.GetAllLearners();

            _mockLearnerRepo.Verify(n => n.GetAllLearners(), Times.Once);
        }

        [Test]
        public void _02Test_GetAllLearners_ReturnsEmptyList()
        {
            //Arrange
            _mockLearnerRepo.Setup(n => n.GetAllLearners()).Returns(_learnersList);
            //Act
            var actual = _mockLearnerRepo.Object.GetAllLearners();
            var expected = _learnersList;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _03Test_GetAllLearners_ReturnsListOf3_WhenCalledWith3Entries()
        {
            _learnersList.Add(_learner);
            _learnersList.Add(_learner);
            _learnersList.Add(_learner);
            _mockLearnerRepo.Setup(n => n.GetAllLearners()).Returns(_learnersList);

            var actual = _mockLearnerRepo.Object.GetAllLearners();
            var expected = _learnersList;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _04Test_GetLearnerById_IsCalledOnce()
        {
            int id = _learner.LearnerId;

            _learner = _mockLearnerRepo.Object.GetLearnerById(id);

            _mockLearnerRepo.Verify(n => n.GetLearnerById(id), Times.Once);
        }

        [Test]
        public void _05Test_GetLearnerById_ReturnsAValidCustomer_WhenCalledWithId1()
        {
            int id = _learner.LearnerId;
            _mockLearnerRepo.Setup(n => n.GetLearnerById(id)).Returns(_learner);

            var actual = _mockLearnerRepo.Object.GetLearnerById(id);
            var expected = _learner;

            Assert.AreEqual(expected, actual);
        }
    }
}
