using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Template.Web.Models;

namespace Template.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("userName","Reshma");

            CookieOptions op = new CookieOptions();
            op.Expires = DateTime.Now.AddMinutes(2);


            HttpContext.Response.Cookies.Append("userName", "Ariwala", op);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
