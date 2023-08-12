using Microsoft.AspNetCore.Mvc;
using RiodeMVCProject.Services.Interfaces;

namespace RiodeMVCProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BannerController : Controller
    {
        readonly IBannerService _bannerservice;

        public BannerController(IBannerService bannerservice)
        {
            _bannerservice = bannerservice;
        }

        public async Task<IActionResult>  Index()
        {
            return View(await _bannerservice.GetAll());
        }
    }
}
