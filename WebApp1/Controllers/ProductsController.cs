using Microsoft.AspNetCore.Mvc;
using WebApp1.Services;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Products";

            return View();
        }

        public IActionResult Search()
        {
            ViewData["Title"] = "Search for Products";
            return View();
        }

    }
}
