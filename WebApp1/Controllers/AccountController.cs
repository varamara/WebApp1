using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Services;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Account";
            return View();
        }
    }
}
