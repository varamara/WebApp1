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

        [HttpPost]
        public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel)
        {
            if (ModelState.IsValid)
            {
                // Convert ViewModel to ProductEntity with selected tags
                ProductEntity productEntity = _productService.ToProductEntity(productRegistrationViewModel);

                if (await _productService.RegisterProductAsync(productEntity))
                    return RedirectToAction("Index", "Products");

                ModelState.AddModelError("", "Something went wrong when creating product");
            }

            // Get available tags from the service
            var availableTags = _productService.GetAvailableTags();

            // Get the three hard-coded tags from the OnModelCreating method
            var hardCodedTagNames = new List<string> { "new", "Featured", "Popular" };

            // Find the database tags that match the hard-coded tag names
            var matchingDatabaseTags = availableTags.Where(tag => hardCodedTagNames.Contains(tag.TagName)).ToList();

            // Create a list of TagEntity instances that match the database tags
            var matchingDatabaseTagEntities = matchingDatabaseTags.Select(tag => new TagEntity { Id = tag.Id, TagName = tag.TagName }).ToList();

            // Assign matched database tag entities to the view model
            productRegistrationViewModel.AvailableTags = matchingDatabaseTagEntities;

            return View(productRegistrationViewModel);

     
        }




        public IActionResult Search()
        {
            ViewData["Title"] = "Search for Products";
            return View();
        }
    }
}
