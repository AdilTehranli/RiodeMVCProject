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

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int? id)
        {
            if (id == null || id < 1) throw new ArgumentException();
            var entity= await _context.Products.FindAsync(id);
            if (entity == null) throw new NullReferenceException();
            return entity;
        }

        public Task Update(UpdateProductVM Productvm)
        {
            throw new NotImplementedException();
        }
    }
}
