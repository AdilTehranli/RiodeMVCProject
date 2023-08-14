using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.ExtensionServices.Interfaces;
using RiodeMVCProject.Models;
using RiodeMVCProject.Services.Interfaces;
using RiodeMVCProject.ViewModels.ProductVMs;

namespace RiodeMVCProject.Services.Implements
{
    public class ProductService : IProductService
    {
        readonly RiodeDbContext _context;
        readonly IFileService _fileService;

        public ProductService(RiodeDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public  async Task Create(CreateProductVM Productvm)
        {
            Product pr = new Product()
            {
                Name = Productvm.Name,
                Category = Productvm.Category,
                Price = Productvm.Price,
                Raiting= Productvm.Raiting,
                ProductImage=await _fileService.UploadAsync(Productvm.ProductImage,Path.Combine("images","img"))
            };
            await _context.AddAsync(pr);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await GetById(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAll(bool takeAll)
        {
            if (takeAll)
            {
                return await _context.Products.ToListAsync();
            }
            return await _context.Products.Where(p => p.IsDeleted == false).ToListAsync();
        }

        public async Task<Product> GetById(int? id)
        {
            if (id == null || id < 1) throw new ArgumentException();
            var entity= await _context.Products.FindAsync(id);
            if (entity == null) throw new NullReferenceException();
            return entity;
        }

        public async Task SoftDelete(int? id)
        {
            var entity = await GetById(id);
            entity.IsDeleted = !entity.IsDeleted;
            await _context.SaveChangesAsync();
        }

        public async Task Update(UpdateProductVM Productvm)
        {
            var entity = await GetById(Productvm.Id);
            entity.Category = Productvm.Category;
            entity.Price = Productvm.Price; 
            entity.Name = Productvm.Name;
            entity.Price=Productvm.Price;
            entity.Raiting = Productvm.Raiting;
            await _context.SaveChangesAsync();   
        }
    }
}
