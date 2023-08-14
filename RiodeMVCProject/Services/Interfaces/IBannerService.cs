using RiodeMVCProject.Models;
using RiodeMVCProject.ViewModels.BannerVMs;
using RiodeMVCProject.ViewModels.SliderVMs;

namespace RiodeMVCProject.Services.Interfaces
{
    public interface IBannerService
    {
        Task Create(CreateBannerVM bannerVM);
        Task Update(UpdateBannerVM bannerVM);
        Task Delete(int? id);
        Task<ICollection<Banner>> GetAll();
        Task<Banner> GetById(int? id);
    }
}
