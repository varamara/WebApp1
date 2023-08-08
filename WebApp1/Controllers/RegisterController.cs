using Microsoft.AspNetCore.Mvc;
using WebApp1.ViewModels;
using WebApp1.Services;

namespace WebApp1.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AuthenticationService _auth;

        public RegisterController(AuthenticationService auth)
        {
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
                    ModelState.AddModelError("", "An account with the same e-mail already exists.");
 
                if (await _auth.RegisterUserAsync(viewModel))
                    return RedirectToAction("index", "login");
            }

            return View(viewModel);
        }
    }
}
