using Microsoft.AspNetCore.Mvc;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.Services.Interfaces;

namespace RiodeMVCProject.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
       readonly RiodeDbContext _context;
        readonly IProductService _productService;

        public ProductController(RiodeDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public async Task<IActionResult>  Index()
        {
            return View(await _productService.GetAll());
        }

    }
}
