using Microsoft.AspNetCore.Mvc;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                BestCollection = new GridCollectionViewModel
                {
                    Title = "Best Collection",
                    Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptops", "Mobile", "Beauty" },
                    GridItems = new List<GridCollectionItemViewModel>
                    {
                        new GridCollectionItemViewModel { Id = "1" , Title = "Apple watch collection", Price = 10, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "2" , Title = "Table Lamp", Price = 20, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "3" , Title = "laptop thinkpad lenovo", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "4" , Title = "Table Lamp", Price = 40, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "5" , Title = "Gumshoes black fashion", Price = 50, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "6" , Title = "Woman white dress", Price = 60, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "7" , Title = "Kettle water boiler", Price = 70, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "8" , Title = "Congee rice cooker", Price = 80, ImageUrl = "images/placeholders/270x295.svg" }
                    }
                },

                Promotion = new PromotionViewModel {
                    PromotionItem_1 = new List<GridCollectionItemViewModel>
                    {
                        new GridCollectionItemViewModel { Id = "1" , Title = "Table Lamp - scelerisque tempore", Price = 50, ImageUrl = "images/placeholders/369x310.svg" },
                    }, 
                    
                    PromotionItem_2 = new List<GridCollectionItemViewModel>
                    {
                        new GridCollectionItemViewModel { Id = "2" , Title = "Table Lamp - scelerisque tempore", Price = 30, ImageUrl = "images/placeholders/369x310.svg" },
                    }
                },
            };

            return View(viewModel);
        }
    }
}
