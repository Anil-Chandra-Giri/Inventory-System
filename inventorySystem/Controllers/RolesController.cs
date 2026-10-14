using Microsoft.AspNetCore.Mvc;

namespace inventorySystem.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
