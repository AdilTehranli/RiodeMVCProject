using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.Models;
using RiodeMVCProject.Services.Interfaces;

namespace RiodeMVCProject.Services.Implements;

public class CategoryService : ICategoryService
{
    readonly RiodeDbContext _context;
    List<Product> _products;
    public CategoryService(RiodeDbContext context)
    {
        _context = context;
        _products=  _context.Products.Include(p => p.ProductCategories).ThenInclude(pc => pc.Category).Where(p => p.IsDeleted == false).ToList();
    }

    public IQueryable<Category> GetTable => _context.Set<Category>();

    public Task CheckProductCategoryDelete(int? id)
    {
        throw new NotImplementedException();
    }

    public async Task Create(string name)
    {
        if (name == null) throw new ArgumentNullException();
        if (await _context.Categories.AnyAsync(c => c.Name == name)) throw new Exception();
        await _context.Categories.AddAsync(new Category() { Name = name });
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int? id)
    {

        var entity=await GetById(id);
        if (entity == null) throw new Exception();
        if (_products == null) throw new Exception();
        var categories=_products.Any(c => c.ProductCategories.Any(p=>p.Category.Equals(entity)));
        if(categories) throw new Exception();
        _context.Categories.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Category>> GetAll()
     => await _context.Categories.ToListAsync();

    public async Task<Category> GetById(int? id)
    {
        if (id < 1 || id == null) throw new ArgumentException();
        var entity = await _context.Categories.FindAsync(id);
        if (entity == null) throw new ArgumentNullException();
        return entity;
    }

    public async Task<bool> IsAllExist(List<int> ids)
    {
        foreach (var id in ids)
        {
            if (!await IsExist(id))
                return false;
        }
        return true;
    }

    public async Task<bool> IsExist(int id)
       => await _context.Categories.AnyAsync(c => c.Id == id);

    public Task Update(int? id, string name)
    {
        throw new NotImplementedException();
    }
}
