using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
			var entity = await _productService.GetTable.Include(p => p.productImages).SingleOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);
			if (entity == null) return NotFound();
			return View(entity);
        }
     
    }
}
