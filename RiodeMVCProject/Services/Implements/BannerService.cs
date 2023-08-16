using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.DataAccess;
using RiodeMVCProject.ExtensionServices.Interfaces;
using RiodeMVCProject.Models;
using RiodeMVCProject.Services.Interfaces;
using RiodeMVCProject.ViewModels.BannerVMs;
using RiodeMVCProject.ViewModels.SliderVMs;

namespace RiodeMVCProject.Services.Implements
{
    public class BannerService : IBannerService
    {
        readonly RiodeDbContext _context;
        readonly IFileService _fileService;

        public BannerService(RiodeDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task Create(CreateBannerVM bannerVM)
        {
            Banner bm = new Banner()
            {
                BannerImage = await _fileService.UploadAsync(bannerVM.BannerImage,Path.Combine("images","img")),
                Subtitle= bannerVM.Subtitle, 
                Title= bannerVM.Title,
                
            };
            await _context.AddAsync(bm);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await GetById(id);
            _context.Banners.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Banner>> GetAll()
        {
            return await _context.Banners.ToListAsync(); 
        } 

        public async Task<Banner> GetById(int? id)
        {
            if (id < 1 || id == null) throw new ArgumentException();
            var entity = await _context.Banners.FindAsync(id);
            if (entity == null) throw new ArgumentNullException();
            return entity;
        }

        public async Task Update(UpdateBannerVM bannerVM)
        {
            var entity = await GetById(bannerVM.Id);
            entity.Subtitle = bannerVM.Subtitle;    
            entity.Title = bannerVM.Title;
            if (bannerVM.BannerImage != null)
            {
                _fileService.Delete(entity.BannerImage);
                entity.BannerImage = await _fileService.UploadAsync(bannerVM.BannerImage, Path.Combine("images", "img"));
            }
            await _context.SaveChangesAsync();
        }
    }
}
