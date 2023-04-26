using Microsoft.AspNetCore.Mvc;
using WebApp1.Services;
using WebApp1.ViewModels;

namespace WebApp1.Controllers;

public class AccountController : Controller
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }


    public IActionResult Register()
    {
        ViewData["Title"] = "Register";

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
       
        if (ModelState.IsValid)
        {
            if (await _userService.UserExists(x => x.Email == registerViewModel.Email))
            {
                ModelState.AddModelError("", "A user with that email address already exists.");
            }
            else
            {
                if (await _userService.RegisterAsync(registerViewModel))
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError("", "Something went wrong.");
            } 
        }

        return View(registerViewModel);
    }

    public IActionResult Login()
    {
        ViewData["Title"] = "Login";

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            if(await _userService.LoginAsync(loginViewModel))
                return RedirectToAction("Index", "Account");
            
            ModelState.AddModelError("", "Invalid email or password");
        }
        
        return View(loginViewModel);
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Account";
        return View();
    }

}
