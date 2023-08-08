using Microsoft.AspNetCore.Mvc;
using WebApp1.Services;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Products";

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel)
        {
            if(ModelState.IsValid)
            {
                if(await _productService.CreateAsync(productRegistrationViewModel))
                    return RedirectToAction("Index", "Products");

                ModelState.AddModelError("", "Something went wrong when creating product");

            }

            return View();
        }

        public IActionResult Search()
        {
            ViewData["Title"] = "Search for Products";
            return View();
        }
    }
}
