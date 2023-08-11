using Microsoft.AspNetCore.Mvc;
using RiodeMVCProject.Services.Interfaces;

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
            return View(await _sliderservice.GetAll());
        }
    }
}
