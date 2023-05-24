using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using SchoolGradeManager.Models;

namespace SchoolGradeManager.Controllers
{
    public class LoginController : Controller
    {
        private readonly StudentManagerContext _context;
        public LoginController(StudentManagerContext context)
        {
            _context = context;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            foreach (var element in _context.userLogins) {
                if (username != null && password != null && username.Equals(element.username) && BCrypt.Net.BCrypt.Verify(password, element.password))
                {
                    HttpContext.Session.SetString("username", username);
                    return Redirect("Student/Index");
                }
                else
                {
                    ViewBag.error = "Niepoprawne dane";
                    return View("Index");
                }
            }
            return View("Index");
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}
