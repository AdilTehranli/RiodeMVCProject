using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        readonly ICategoryService _categoryService;

        public ProductController(RiodeDbContext context, IProductService productService, ICategoryService categoryService)
        {
            _context = context;
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult>  Index()
        {
            return View(await _productService.GetTable.Include(p => p.ProductCategories).ThenInclude(pc => pc.Category).ToListAsync());
        }
        public IActionResult Create() 
        {
            ViewBag.Categories = new SelectList(_categoryService.GetTable, "Id", "Name");

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
                        ModelState.AddModelError("ProductImage", "Wrong file type");
                    if (!createProduct.ProductImage.IsSizeValid(2))
                        ModelState.AddModelError("ProductImage", "File max size is 2mb");

                }
                if (createProduct.ImageFiles != null)
                {
                    foreach (var img in createProduct.ImageFiles)
                    {

                    if (!img.IsTypeValid("image"))
                        ModelState.AddModelError("ImageFile", "Wrong file type"+img.FileName);
                    if (!img.IsSizeValid(2))
                        ModelState.AddModelError("ImageFile", "File max size is 2mb" + img.FileName);
                    }
                }
                if (ModelState.IsValid)
                {
                    ViewBag.Categories = new SelectList(_categoryService.GetTable, "Id", "Name");
                    return View(createProduct);
                }
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
            
                await _productService.Delete(id);
            TempData["IsDeleted"] = true;
            return RedirectToAction(nameof(Index));
           
        }
        public async Task<IActionResult> ChangeStatus(int? id)
        {

            await _productService.SoftDelete(id);
            TempData["IsDeleted"] = true;
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int? id)
        {
			if (id == null || id <= 0) return BadRequest();
			var entity = await _productService.GetTable.Include(p => p.productImages).SingleOrDefaultAsync(p => p.Id == id);
			if (entity == null) return BadRequest();
			UpdateProductGETVM vm = new UpdateProductGETVM
			{
				Name = entity.Name,
				Raiting = entity.Raiting,
				Price = entity.Price,
				ProductImage = entity.ProductImage,
                ProductImages=entity.productImages
			};
			return View(vm);
		}
        [HttpPost]
        public async Task<IActionResult> Update(int? id,UpdateProductGETVM productGETVM)
        {
            if (id == null || id <= 0) return BadRequest();
            var entity = await _productService.GetById(id);
            if (entity == null) return BadRequest();
            UpdateProductVM updateVm = new UpdateProductVM
            {

                Name = productGETVM.Name,
                Raiting = productGETVM.Raiting,
                Price = productGETVM.Price,
                ProductImage = productGETVM.ProductImageFile,
                ProductImages = productGETVM.ProductImagesFiles
            };
            await _productService.Update(id, updateVm);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteImage(int id)
        {
            if (id == null || id <= 0) return BadRequest();
            await _productService.DeleteImage(id);
            return Ok();
        }
    }
}
