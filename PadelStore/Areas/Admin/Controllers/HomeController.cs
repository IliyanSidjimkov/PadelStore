using Microsoft.AspNetCore.Mvc;

namespace PadelStore.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
