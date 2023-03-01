using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolGradeManager.Models;

namespace SchoolGradeManager.Controllers
{
    public class LoginController : Controller
    {       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account, string returnUrl)
        {
            if(!string.IsNullOrEmpty(account.Login) && !string.IsNullOrEmpty(account.Password))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            return View();
        }
    }
}
