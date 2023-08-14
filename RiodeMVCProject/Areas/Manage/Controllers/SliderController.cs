using Microsoft.AspNetCore.Mvc;
using RiodeMVCProject.Extensions;
using RiodeMVCProject.Services.Interfaces;
using RiodeMVCProject.ViewModels.SliderVMs;

namespace RiodeMVCProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        readonly ISliderService _sliderservice;

        public SliderController(ISliderService sliderservice)
        {
            _sliderservice = sliderservice;
        }

        public async Task<IActionResult>Index()
        {
            try
            {

            return View(await _sliderservice.GetAll());
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVM sliderVM)
        {
            try
            {
                if(sliderVM.SliderImage != null)
                {
                    if (!sliderVM.SliderImage.IsTypeValid("image"))
                        ModelState.AddModelError("ImageFile", "Wrong file type");
                    if (!sliderVM.SliderImage.IsSizeValid(2))
                        ModelState.AddModelError("ImageFile", "File max size is 2mb");
                }
                if (!ModelState.IsValid) return View();
                await _sliderservice.Create(sliderVM);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}
