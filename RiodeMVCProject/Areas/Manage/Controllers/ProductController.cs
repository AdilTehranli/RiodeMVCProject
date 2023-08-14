using Microsoft.AspNetCore.Mvc;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.Extensions;
using RiodeMVCProject.Models;
using RiodeMVCProject.Services.Interfaces;
using RiodeMVCProject.ViewModels.BannerVMs;
using RiodeMVCProject.ViewModels.ProductVMs;

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
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProduct)
        {
            try
            {
                if (createProduct.ProductImage != null)
                {
                    if (!createProduct.ProductImage.IsTypeValid("image"))
                        ModelState.AddModelError("ImageFile", "Wrong file type");
                    if (!createProduct.ProductImage.IsSizeValid(2))
                        ModelState.AddModelError("ImageFile", "File max size is 2mb");
                }
                if (!ModelState.IsValid) return View();
                await _productService.Create(createProduct);
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
                await _productService.Delete(id);
                TempData["IsDeleted"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> Update(int? id)
        {
            try
            {
                return View(await _productService.GetById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,UpdateProductVM updateProduct)
        {
            try
            {
                await _productService.Update(updateProduct);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
