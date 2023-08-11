using RiodeMVCProject.Models;

namespace RiodeMVCProject.Services.Interfaces;

public interface ISliderService
{

    Task Create(string name);
    Task Update(string name);
    Task Delete(int? id);
    Task<ICollection<Slider>> GetAll();
    Task<Slider> GetById(int? id);
}
