using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.Services.Interfaces;
using RiodeMVCProject.ViewModels.HomeVMs;

namespace RiodeMVCProject.Controllers
{
    public class HomeController : Controller
    {
        readonly ISliderService _sliderService;
        readonly IProductService _productService;
        readonly IBannerService _bannerService;
        public HomeController( ISliderService sliderService, IProductService productService, IBannerService bannerService)
        {
            _sliderService = sliderService;
            _productService = productService;
            _bannerService = bannerService;
        }

        public async Task<IActionResult>  Index()
        {
            HomeVM vm = new HomeVM()
            {
                Sliders = await _sliderService.GetAll(),
                Banners=await _bannerService.GetAll(),
                Products=await _productService.GetAll(false),
                
            };
            return View(vm);
        }

       
        
    }
}