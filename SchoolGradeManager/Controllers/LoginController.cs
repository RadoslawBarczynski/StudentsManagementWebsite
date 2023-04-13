using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolGradeManager.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null && username.Equals("admin") && password.Equals("admin"))
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

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}
