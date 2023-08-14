using RiodeMVCProject.Models;
using RiodeMVCProject.ViewModels.SliderVMs;

namespace RiodeMVCProject.Services.Interfaces;

public interface ISliderService
{

    Task Create(CreateSliderVM createSlider);
    Task Update(string name);
    Task Delete(int? id);
    Task<ICollection<Slider>> GetAll();
    Task<Slider> GetById(int? id);
}
