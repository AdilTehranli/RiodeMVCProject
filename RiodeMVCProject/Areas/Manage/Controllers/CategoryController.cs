using Microsoft.AspNetCore.Mvc;

namespace RiodeMVCProject.Areas.Manage.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
