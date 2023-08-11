using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.Models;
using RiodeMVCProject.Services.Interfaces;

namespace RiodeMVCProject.Services.Implements
{
    public class SliderService : ISliderService
    {
        readonly RiodeDbContext _context;

        public SliderService(RiodeDbContext context)
        {
            _context = context;
        }

        public Task Create(string name)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Slider>> GetAll()
        {
           return await _context.Sliders.ToListAsync();
        }

        public Task<Slider> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(string name)
        {
            throw new NotImplementedException();
        }
    }
}
