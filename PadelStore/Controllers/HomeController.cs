using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PadelStore.Models;
using System.Diagnostics;

namespace PadelStore.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        

        [AllowAnonymous]
        [Route("Home/Error")]
        [Route("Home/Error/{statusCode}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode = 0)
        {
            

            if (statusCode == StatusCodes.Status404NotFound)
            {
                return View("NotFound");
            }

            if (statusCode == StatusCodes.Status500InternalServerError)
            {
                return View("ServerError");
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
