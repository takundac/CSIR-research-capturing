using Microsoft.AspNetCore.Mvc;

namespace CBIB.Controllers
{
    public class UserManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
