using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.Services.Interfaces;
using RiodeMVCProject.ViewModels.HomeVMs;

namespace RiodeMVCProject.Controllers
{
    public class HomeController : Controller
    {
        readonly RiodeDbContext _context;
        readonly ISliderService _sliderService;
        public HomeController(RiodeDbContext context, ISliderService sliderService)
        {
            _context = context;
            _sliderService = sliderService;
        }

        public async Task<IActionResult>  Index()
        {
            HomeVM vm = new HomeVM()
            {
                Sliders = await _sliderService.GetAll(),
                Banners=await _context.Banners.ToListAsync(),
                Products=await _context.Products.ToListAsync(),
                
            };
            return View(vm);
        }

       
        
    }
}