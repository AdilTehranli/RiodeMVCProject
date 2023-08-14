using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.ExtensionServices.Interfaces;
using RiodeMVCProject.Models;
using RiodeMVCProject.Services.Interfaces;
using RiodeMVCProject.ViewModels.SliderVMs;

namespace RiodeMVCProject.Services.Implements
{
    public class SliderService : ISliderService
    {
        readonly RiodeDbContext _context;
        readonly IFileService _fileService;

        public SliderService(RiodeDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task Create(CreateSliderVM createSlider)
        {
            Slider sd = new Slider()
            {
                SliderImage=await _fileService.UploadAsync(createSlider.SliderImage,Path.Combine("images","img")),
                Description=createSlider.Description,
                DisCount=createSlider.DisCount,
                SubTitle=createSlider.SubTitle,
                Title =createSlider.Title,
                
            };
            await _context.AddAsync(sd);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Slider>> GetAll()
        {
           return await _context.Sliders.ToListAsync();
        }

        public async Task<Slider> GetById(int? id)
        {
            return await _context.Sliders.FindAsync(id);
        }

        public Task Update(string name)
        {
            throw new NotImplementedException();
        }
    }
}
