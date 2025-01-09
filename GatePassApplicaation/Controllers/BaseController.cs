using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GatePassApplicaation.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
            {
                context.Result = RedirectToAction("Login", "Auth");
            }
            base.OnActionExecuting(context);
        }
    }
}
