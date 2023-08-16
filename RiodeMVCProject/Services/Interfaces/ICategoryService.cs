using RiodeMVCProject.Models;

namespace RiodeMVCProject.Services.Interfaces;

public interface ICategoryService
{
    IQueryable<Category> GetTable { get; }
    Task Create(string name);
    Task Update(int? id, string name);
    Task Delete(int? id);
    Task<ICollection<Category>> GetAll();
    Task<Category> GetById(int? id);
    Task<bool> IsExist(int id);
    Task<bool> IsAllExist(List<int> ids);
}
