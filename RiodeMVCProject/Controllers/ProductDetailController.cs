using Microsoft.AspNetCore.Mvc;
using RiodeMVCProject.Services.Interfaces;

namespace RiodeMVCProject.Controllers
{
    public class ProductDetailController : Controller
    {
        readonly IProductService _productService;

		public ProductDetailController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int? id)
        {
			if (id == null || id <= 0) return BadRequest();
            var entity = await _productService.GetById(id);
            if(entity == null) return NotFound();
			return View(entity);
        }
     
    }
}
