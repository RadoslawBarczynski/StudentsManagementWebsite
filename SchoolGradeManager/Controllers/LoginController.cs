using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using SchoolGradeManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace SchoolGradeManager.Controllers
{
    [IgnoreAntiforgeryToken]
    public class LoginController : Controller
    {
        private readonly StudentManagerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginController(StudentManagerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
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
                    //HttpContext.Session.SetString("username", username);
                    _httpContextAccessor.HttpContext.Session.SetString("username", username);
                    return Redirect("Student/Index");
                }
                //else
                //{
                //    ViewBag.error = "Niepoprawne dane";
                //    return View("Index");
                //}
            }
            return View("Index");
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            //HttpContext.Session.Remove("username");
            _httpContextAccessor.HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}
