using Microsoft.AspNetCore.Mvc;
using WebApp1.Services;
using WebApp1.Models.Entities;

namespace WebApp.Controllers
{
    public class ProductCategoriesController : ControllerBase
    {
        private readonly ProductCategoryService _productCategoryService;

        public ProductCategoriesController(ProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCategoryEntity categoryEntity)
        {
            if (ModelState.IsValid)
            {
                var categoryName = categoryEntity.CategoryName; // Antag att din entitet har ett CategoryName-fält
                var category = await _productCategoryService.GetProductCategoryAsync(categoryName);
                if (category != null)
                    return Conflict(new { category, error = "A category with the same name already exists." });

                category = await _productCategoryService.CreateProductCategoryAsync(categoryName);
                if (category != null)
                    return Created("", category);
            }
            return BadRequest(categoryEntity);
        }


        [HttpGet]
        public async Task<IActionResult> Get(string? categoryName)
        {
            if (!string.IsNullOrEmpty(categoryName))
            {
                var _category = await _productCategoryService.GetProductCategoryAsync(categoryName);
                if (_category != null)
                    return Ok(_category);
            }
            else
            {
                var categories = await _productCategoryService.GetProductCategoriesAsync();
                if (categories != null)
                    return Ok(categories);
            }

            return NotFound();
        }
    }
}