using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CC_SchoolProject_RestApi.Models;
using CC_SchoolProject_RestApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using CC_SchoolProject_RestApi.PageModels;
using NuGet.DependencyResolver;
using log4net;

namespace CC_SchoolProject_RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTeachersController : ControllerBase
    {
        private static readonly ILog logger = LogManager.GetLogger("AdminTeacherController");
        private readonly CodeCrusaders_School_Management_DBContext _context;

        TeacherRepo _repo;

        public AdminTeachersController(CodeCrusaders_School_Management_DBContext context)
        {
            _context = context;
            _repo = new TeacherRepo(_context);

        }

        [HttpGet]
        [Route("ReadAll")]
        public async Task<ActionResult<IEnumerable<Teacher>>> Teachers()
        {
            logger.Info("TeachersController - Get : /api/Teachers/ReadAll");

            return await _context.Teachers.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherByID(int id)
        {
            logger.Info("AdminTeachersController - GET: api/AdminTeachers/" + id);
            List<Teacher> brokersTrades = new List<Teacher>();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teachers = await _context.Teachers.FindAsync(id);

            if (teachers == null)
            {

                return NotFound();
            }
            return Ok(teachers);
        }



        [HttpPost]
        public IActionResult CreateNewTeacher(TeacherAddressVM teacherVM)
        {
            _repo.CreateNewTeacher(teacherVM);
            return Ok($"{teacherVM.FirstName} Created Successfully!");
        }



        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutTeacher(int id, TeacherVM teacher)
        {
            logger.Info("AdminTeacherController - Update : /api/AdminTeacher/Update TeacherID: " + id);


            if (id != teacher.TeacherId)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
                {

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(new { message = $"Teacher successfully {id} updated." });
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.TeacherId == id);

        }

        [HttpDelete]
        [Route("Deactivate")]

        public async Task<ActionResult<Teacher>> DeactivateTeacher(int id)
        {
            logger.Info("AdminTeacherController - Delete : /api/AdminTeacher/Delete TeacherID: " + id);


            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
                return Ok(teacher);
            }
            else
            {


                return NotFound();
            }



        }
    }
}
