using Microsoft.AspNetCore.Mvc;

namespace fruit_manager_app.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
