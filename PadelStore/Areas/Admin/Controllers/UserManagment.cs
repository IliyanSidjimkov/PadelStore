using Microsoft.AspNetCore.Mvc;

namespace PadelStore.Areas.Admin.Controllers
{
    public class UserManagment : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
