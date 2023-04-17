using Microsoft.AspNetCore.Mvc;
using WebApp1.Services;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
{
    public class ProductDetailsController : Controller
    {
        public IActionResult Index(int id)
        {

            var viewModel = new ProductDetailsIndexViewModel
            {
                ProductDetails = new ProductDetailsViewModel
                {

                }

            };

            return View(viewModel);
        }
    }
}
