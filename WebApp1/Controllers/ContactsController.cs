using Microsoft.AspNetCore.Mvc;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Contact Us";

            return View();
        }
    }
}
