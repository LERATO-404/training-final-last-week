using CC_SchoolProject_RestApi.Models;
using CC_SchoolProject_RestApi.PageModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CC_SchoolProject_RestApi.Repositories
{
    public class AdminLearnersRepo
    {
        private readonly CodeCrusaders_School_Management_DBContext _context;

        public AdminLearnersRepo(CodeCrusaders_School_Management_DBContext context)
        {
            _context = context;
        }

        public virtual List<Learner> GetAllLearners()
        {
            List<Learner> allLearners = _context.Learners.ToList();

            return allLearners;
        }

        public virtual Learner GetLearnerById(int id)
        {
            var learner = _context.Learners.Find(id);

            if (learner == null)
            {
                return null;
            }
            return learner;
        }

        // Address first, Address Id, then Guardian...Id, the Learner...Id
        public void CreateNewLearner(LearnerGuardianAddressVM learnerVM)
        {
            // Address
            var address = new Address
            {
                AddressLine = learnerVM.AddressLine,
                Suburb = learnerVM.Suburb,
                PostalCode = learnerVM.PostalCode
            };

            _context.Set<Address>().Add(address);
            _context.SaveChanges();
            var addressId = address.AddressId;

            // Guardian
            var guardian = new Guardian
            {
                AddressId = addressId,
                FirstName = learnerVM.GuardianFirstName,
                LastName = learnerVM.GuardianLastName,
                Relationship = learnerVM.Relationship,
                Contact = learnerVM.Contact,
            };

            _context.Set<Guardian>().Add(guardian);
            _context.SaveChanges();
            var guardianId = guardian.AddressId;

            // Learner
            var learner = new Learner
            {
                GuardianId = guardianId,
                FirstName = learnerVM.FirstName,
                LastName = learnerVM.LastName,
                StartDate = learnerVM.StartDate,
                DateOfBirth = learnerVM.DateOfBirth,
            };

            _context.Set<Learner>().Add(learner);
            _context.SaveChanges();
        }
    }
}
