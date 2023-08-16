﻿using Microsoft.EntityFrameworkCore;
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

        public IQueryable<Product> GetTable { get => _context.Set<Product>(); }

        public async Task Create(CreateProductVM Productvm)
        {
            Product entity = new Product()
            {
                Name = Productvm.Name,
                Category = Productvm.Category,
                Price = Productvm.Price,
                Raiting= Productvm.Raiting,
                ProductImage=await _fileService.UploadAsync(Productvm.ProductImage,Path.Combine("images","img"))
            };
            if (Productvm.ImageFiles != null)
            {
            List<ProductImage> imgs = new();
                foreach (var item in Productvm.ImageFiles)
                {
                    string filename = await _fileService.UploadAsync(item, Path.Combine("images", "img"));
                   
                    imgs.Add(new ProductImage
                    {
                        Name = filename,
                    });
                }
                entity.productImages= imgs;
            }
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await GetById(id,true);
            _context.Remove(entity);
            _fileService.Delete(entity.ProductImage);
			if (entity.productImages != null)
			{
				foreach (var item in entity.productImages)
				{
					_fileService.Delete(item.Name);
				}
			}
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

        public async Task<Product> GetById(int? id, bool takeAll = false)
        {

			if (id == null || id < 1) throw new ArgumentException();
			Product? entity;
			if (takeAll)
			{
				entity = await _context.Products.FindAsync(id);
			}
			else
			{
				entity = await _context.Products.SingleOrDefaultAsync(p => p.IsDeleted == false && p.Id == id);
			}
			if (entity is null) throw new NullReferenceException();
			return entity;
        }

        public async Task SoftDelete(int? id)
        {
            var entity = await GetById(id,true);
            entity.IsDeleted = !entity.IsDeleted;
            await _context.SaveChangesAsync();
        }

        public async Task Update(int? id,UpdateProductVM Productvm)
        {
            var entity = await GetById(id);
            entity.Category = Productvm.Category;
            entity.Price = Productvm.Price; 
            entity.Name = Productvm.Name;
            entity.Price=Productvm.Price;
            entity.Raiting = Productvm.Raiting;
            if(entity.ProductImage != null)
            {
                _fileService.Delete(entity.ProductImage);
                _fileService.UploadAsync(Productvm.ProductImage, Path.Combine("images", "img"));
            }
			if (Productvm.ProductImages != null)
			{
				if (entity.productImages == null) entity.productImages = new List<ProductImage>();
				foreach (var img in Productvm.ProductImages)
				{

					ProductImage prodImg = new ProductImage
					{
						Name = await _fileService.UploadAsync(img, Path.Combine("assets", "imgs", "products"))
					};
					entity.productImages.Add(prodImg);

				}
			}
			await _context.SaveChangesAsync();   
        }
    }
}
