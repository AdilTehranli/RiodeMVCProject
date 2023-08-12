using RiodeMVCProject.Models;

namespace RiodeMVCProject.Services.Interfaces
{
    public interface IBannerService
    {
        Task Create(string name);
        Task Update(string name);
        Task Delete(int? id);
        Task<ICollection<Banner>> GetAll();
        Task<Banner> GetById(int? id);
    }
}
