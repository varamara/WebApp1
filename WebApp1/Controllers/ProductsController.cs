using Microsoft.AspNetCore.Mvc;
using WebApp1.Models.Entities;
using WebApp1.Services;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        private readonly ProductCategoryService _productCategoryService;

        public ProductsController(ProductService productService, ProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }
        public IActionResult Details()
        {
            ViewData["Title"] = "Product Details";
            return View();
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Products";
            return View();
        }

        public IActionResult Register()
        {
            var categories = _productCategoryService.GetProductCategoriesAsync().Result;
            var viewModel = new ProductRegistrationViewModel
            {
                Categories = categories.Select(c => new CategoryViewModel { Id = c.Id, CategoryName = c.CategoryName }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(ProductRegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Anropa ProductService för att skapa produkten med uppgifterna från viewModel
                await _productService.CreateProductAsync(viewModel.ProductName, viewModel.ProductDescription, viewModel.ProductImage, viewModel.ProductPrice, viewModel.SelectedCategoryId);

                // Redirect till en annan sida efter att produkten har skapats
                return RedirectToAction("Index");
            }

            // Om det finns valideringsfel, fyll på kategorilistan igen och returnera vyn med felmeddelanden
            var categories = await _productCategoryService.GetProductCategoriesAsync();

            viewModel.Categories = categories.Select(c => new CategoryViewModel { Id = c.Id, CategoryName = c.CategoryName }).ToList();
            return View(viewModel);
        }

        public IActionResult Search()
        {
            ViewData["Title"] = "Search for Products";
            return View();
        }
    }
}
