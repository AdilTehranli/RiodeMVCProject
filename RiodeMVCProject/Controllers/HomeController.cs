using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.ViewModels.HomeVMs;

namespace RiodeMVCProject.Controllers
{
    public class HomeController : Controller
    {
        readonly RiodeDbContext _context;

        public HomeController(RiodeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>  Index()
        {
            HomeVM vm = new HomeVM()
            {
                Sliders = await _context.Sliders.ToListAsync(),
                Banners=await _context.Banners.ToListAsync(),
                
            };
            return View(vm);
        }

       
        
    }
}