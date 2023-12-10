using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SchoolGradeManager.Services
{
    public class SessionFilter : IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string username = _httpContextAccessor.HttpContext.Session.GetString("username");

            if (string.IsNullOrEmpty(username))
            {
                if (!context.HttpContext.Request.Path.StartsWithSegments("/Login"))
                {
                    if (context.ActionDescriptor.DisplayName != "SchoolGradeManager.Controllers.LoginController.Index (SchoolGradeManager)")
                    {
                        context.Result = new RedirectToActionResult("Index", "Login", null);
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }

}
