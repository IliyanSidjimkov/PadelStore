using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PadelStore.Data.Models;
using PadelStore.Models;
using System.Diagnostics;

namespace PadelStore.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {

        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(ILogger<HomeController> logger,UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this.userManager = userManager;
        }
       
        public async Task<IActionResult> Index()
        {
            if (User.Identity!.IsAuthenticated)
            {
                ApplicationUser? user = await userManager.GetUserAsync(User);

                ViewBag.FullName = $"{user?.FirstName} {user?.LastName}";
            }

            return View();
        }
        

        
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
