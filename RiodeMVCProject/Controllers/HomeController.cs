using Microsoft.AspNetCore.Mvc;

namespace RiodeMVCProject.Controllers
{
    public class HomeController : Controller
    {
      

        public IActionResult Index()
        {
            return View();
        }

       
        
    }
}