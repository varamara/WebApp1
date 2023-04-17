using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Cart";
            return View();
        }
    }
}
