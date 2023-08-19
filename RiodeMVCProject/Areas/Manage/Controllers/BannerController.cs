using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiodeMVCProject.Extensions;
using RiodeMVCProject.Models;
using RiodeMVCProject.Services.Implements;
using RiodeMVCProject.Services.Interfaces;
using RiodeMVCProject.ViewModels.BannerVMs;

namespace RiodeMVCProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Create(CreateBannerVM createBanner) 
        {
            try
            {
                if (createBanner.BannerImage != null)
                {
                    if (!createBanner.BannerImage.IsTypeValid("image"))
                        ModelState.AddModelError("ImageFile", "Wrong file type");
                    if (!createBanner.BannerImage.IsSizeValid(2))
                        ModelState.AddModelError("ImageFile", "File max size is 2mb");
                }
                if (!ModelState.IsValid) return View();
                await _bannerservice.Create(createBanner);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                await _bannerservice.Delete(id);
                TempData["IsDeleted"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult>  Update(int? id)
        {
            try
            {
                return View( await _bannerservice.GetById(id));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,UpdateBannerVM updateBanner)
        {
            try
            {
                await _bannerservice.Update(updateBanner);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
