﻿using RiodeMVCProject.Models;
using RiodeMVCProject.ViewModels.ProductVMs;
using System.Collections.ObjectModel;

namespace RiodeMVCProject.Services.Interfaces
{
    public interface IProductService
    {
        IQueryable<Product> GetTable { get; }
        Task Create(CreateProductVM Productvm);
        Task Update(int? id,UpdateProductVM Productvm);
        Task Delete(int? id);
        Task DeleteImage(int? id);

        Task SoftDelete(int? id);
        Task<ICollection<Product>> GetAll(bool takeAll);
        Task<Product> GetById(int? id, bool takeAll = false);
    }
}
