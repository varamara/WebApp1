using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models.Identity;

namespace WebApp1.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogoutController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if(_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();
            return LocalRedirect("/");
        }
    }
}
