using Microsoft.AspNetCore.Mvc;
using WebApp1.Models.Entities;
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

        //[HttpPost]
        //public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ProductEntity productEntity = _productService.ToProductEntity(productRegistrationViewModel);

        //        if (await _productService.RegisterProductAsync(productEntity))
        //            return RedirectToAction("Index", "Products");

        //        ModelState.AddModelError("", "Something went wrong when creating product");
        //    }

        //    return View(productRegistrationViewModel);
        //}

        //Hur får jag produkten att bli tilldelad ett tagId?!

        public IActionResult Search()
        {
            ViewData["Title"] = "Search for Products";
            return View();
        }
    }
}
