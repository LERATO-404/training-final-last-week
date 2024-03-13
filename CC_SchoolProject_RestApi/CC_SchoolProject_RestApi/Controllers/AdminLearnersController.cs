using CC_SchoolProject_RestApi.Models;
using CC_SchoolProject_RestApi.PageModels;
using CC_SchoolProject_RestApi.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CC_SchoolProject_RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminLearnersController : ControllerBase
    {
        private readonly CodeCrusaders_School_Management_DBContext _context;
        AdminLearnersRepo _repo;

        public AdminLearnersController(CodeCrusaders_School_Management_DBContext context)
        {
            _context = context;
            _repo = new AdminLearnersRepo(_context);
        }

        // GET: api/GetAllLearners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Learner>>> GetAllLearners()
        {
            List<Learner> allLearners = new List<Learner>();
            allLearners = _repo.GetAllLearners();
            return allLearners;
        }

        // GET: api/GetLearnerById
        [HttpGet]
        public async Task<ActionResult<Learner>> GetLearnerById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var learner = _repo.GetLearnerById(id);

            if (learner == null)
            {
                return NotFound();
            }

            return learner;
        }

        // POST: api/CreateNewLearner
        [HttpPost]
        public IActionResult CreateNewLearner(LearnerGuardianAddressVM learnerVM)
        {
            _repo.CreateNewLearner(learnerVM);
            return Ok($"{learnerVM.FirstName} Created Successfully!");
        }

        // PUT: api/UpdateLearnerById/5
        [HttpPut]
        public async Task<IActionResult> UpdateLearnerById(int id, Learner learners)
        {
            if (id != learners.LearnerId)
            {
                return BadRequest();
            }

            _context.Entry(learners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearnersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/DeleteLearnerById/5
        [HttpDelete]
        public async Task<ActionResult<Learner>> DeleteLearnerById(int id)
        {
            var brokers = await _context.Learners.FindAsync(id);
            if (brokers == null)
            {
                return NotFound();
            }

            _context.Learners.Remove(brokers);
            await _context.SaveChangesAsync();

            return brokers;
        }

        // Helper Method
        private bool LearnersExists(int id)
        {
            return _context.Learners.Any(e => e.LearnerId == id);
        }
    }
}
