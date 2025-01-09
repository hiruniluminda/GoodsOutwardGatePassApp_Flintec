using GatePassApplicaation.Models;
using Microsoft.AspNetCore.Mvc;

namespace GatePassApplicaation.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AuthController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _appDbContext.users.FirstOrDefault(u=>u.UserName == username && u.Password == password);
            if (user != null) {
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetString("Role",user.Role);

                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "PreparedBy");
                }
                else
                {
                    return RedirectToAction("Index","AuthorizedBy");
                }
            }
            ModelState.AddModelError("", "Invalid UserName Or Password");
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
