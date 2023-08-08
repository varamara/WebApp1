using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Contexts;

namespace WebApp1.Controllers
{
	[Authorize(Roles = "admin")]
	public class AdminController : Controller	
	{

        public IActionResult Index()
		{
			return View();
		}
	}
}
