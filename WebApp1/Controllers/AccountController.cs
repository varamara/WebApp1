using Microsoft.AspNetCore.Mvc;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            return View(registerViewModel);
        }

        public IActionResult Login()
        {
            ViewData["Title"] = "Login";

            return View();
        }




        public IActionResult Index()
        {
            ViewData["Title"] = "Account";
            return View();
        }

    }
}
