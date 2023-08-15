using Microsoft.EntityFrameworkCore;
using RiodeMVCProject.Models;

namespace RiodeMVCProject.DataAccess
{
    public class RiodeDbContext : DbContext
    {
        public RiodeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> productImages { get; set; }
        
    }
}
