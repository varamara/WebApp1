using Microsoft.AspNetCore.Mvc;
using WebApp1.Models.Dtos;
using WebApp1.Models.Entities;
using WebApp1.Models.Schemas;
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

        [HttpGet]
        public async Task<IActionResult> Get(string? articleNumber)
        {
            if (!string.IsNullOrEmpty(articleNumber))
            {
                var product = await _productService.GetProductAsync(articleNumber);
                if (product != null)
                    return Ok(product);
            }
            else
            {
                var products = await _productService.GetProductsAsync();
                if (products != null)
                    return Ok(products);
            }

            return NotFound();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductSchema schema)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.GetProductAsync(schema.ArticleNumber);
                if (product != null)
                    return Conflict(new { product, error = "A product with the same article number already exists." });

                product = await _productService.CreateProductAsync(schema);
                if (product != null)
                    return Created("", product);
            }
            return BadRequest(schema);
        }




        //Hur får jag produkten att bli tilldelad ett tagId?!

        public IActionResult Search()
        {
            ViewData["Title"] = "Search for Products";
            return View();
        }
    }
}
