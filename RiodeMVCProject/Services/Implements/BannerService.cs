using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.Models;
using RiodeMVCProject.Services.Interfaces;

namespace RiodeMVCProject.Services.Implements
{
    public class BannerService : IBannerService
    {
        readonly RiodeDbContext _context;

        public BannerService(RiodeDbContext context)
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

        public async Task<ICollection<Banner>> GetAll()
        {
            return await _context.Banners.ToListAsync(); 
        }

        public Task<Banner> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(string name)
        {
            throw new NotImplementedException();
        }
    }
}
