using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
