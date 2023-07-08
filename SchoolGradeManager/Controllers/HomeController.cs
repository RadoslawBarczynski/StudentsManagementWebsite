using Microsoft.AspNetCore.Mvc;

namespace SchoolGradeManager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
