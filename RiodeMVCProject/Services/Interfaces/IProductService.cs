﻿using RiodeMVCProject.Models;
using RiodeMVCProject.ViewModels.ProductVMs;

namespace RiodeMVCProject.Services.Interfaces
{
    public interface IProductService
    {
        Task Create(CreateProductVM Productvm);
        Task Update(UpdateProductVM Productvm);
        Task Delete(int? id);
        Task<ICollection<Product>> GetAll();
        Task<Product> GetById(int? id);
    }
}