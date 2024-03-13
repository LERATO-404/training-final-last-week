using Microsoft.AspNetCore.Mvc;

namespace CC_SchoolProject_ASP.Areas.Teachers.Controllers
{
    [Area("Teachers")]
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
