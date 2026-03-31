using Microsoft.AspNetCore.Mvc;

namespace PadelStore.Areas.Admin.Controllers
{
    public class UserManagment : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
