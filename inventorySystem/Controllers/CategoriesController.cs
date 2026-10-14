using Microsoft.AspNetCore.Mvc;

namespace inventorySystem.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
