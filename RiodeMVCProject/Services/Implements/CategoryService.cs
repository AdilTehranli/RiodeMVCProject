using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.Models;
using RiodeMVCProject.Services.Interfaces;

namespace RiodeMVCProject.Services.Implements;

public class CategoryService : ICategoryService
{
    readonly RiodeDbContext _context;

    public CategoryService(RiodeDbContext context)
    {
        _context = context;
    }

    public IQueryable<Category> GetTable => throw new NotImplementedException();

    public async Task Create(string name)
    {
        if (name == null) throw new ArgumentNullException();
        if (await _context.Categories.AnyAsync(c => c.Name == name)) throw new Exception();
        await _context.Categories.AddAsync(new Category() { Name = name });
        await _context.SaveChangesAsync();
    }

    public Task Delete(int? id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Category>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetById(int? id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsAllExist(List<int> ids)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExist(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(int? id, string name)
    {
        throw new NotImplementedException();
    }
}
