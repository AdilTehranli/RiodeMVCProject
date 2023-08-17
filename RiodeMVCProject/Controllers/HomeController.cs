using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.Services.Interfaces;
using RiodeMVCProject.ViewModels.BasketVMs;
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
        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            //var model = await _productService.GetById(id);
            if (!await _productService.GetTable.AnyAsync(p => p.Id == id)) return NotFound();
            var basket = HttpContext.Request.Cookies["basket"];
            List<BasketItemVM> items = basket == null ? new List<BasketItemVM>() : JsonConvert.DeserializeObject<List<BasketItemVM>>(basket);
            var item = items.SingleOrDefault(i => i.Id == id);
            if (item == null)
            {
                item = new BasketItemVM
                {
                    Id = (int)id,
                    Count = 1
                };
                items.Add(item);
            }
            else
            {
                item.Count++;
            }
            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(items));
            return Ok();
        }
        public async Task<IActionResult> GetBasket()
        {
            var basket = JsonConvert.DeserializeObject<List<BasketItemVM>>(HttpContext.Request.Cookies["basket"]);
            List<BasketItemProductVm> vm = new List<BasketItemProductVm>();
            foreach (var item in basket)
            {
                vm.Add(new BasketItemProductVm
                {
                    Count = item.Count,
                    Product = await _productService.GetById(item.Id),
                });
            }
            return PartialView("_BasketPartial", vm);
        }


    }
}