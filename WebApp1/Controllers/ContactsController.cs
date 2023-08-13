using Microsoft.AspNetCore.Mvc;
using WebApp1.Services;
using WebApp1.ViewModels;

namespace WebApp1.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Contact Us";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _contactService.RegisterMessageAsync(viewModel);
                return RedirectToAction("Index", "Home"); 
            }
            return View(viewModel);
        }
    }
}
