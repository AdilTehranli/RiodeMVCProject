using RiodeMVCProject.ExtensionServices.Implements;
using RiodeMVCProject.ExtensionServices.Interfaces;
using RiodeMVCProject.Services.Implements;
using RiodeMVCProject.Services.Interfaces;

namespace RiodeMVCProject.Services
{
    public static class ServiceRegistration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<ISliderService,SliderService> ();
            services.AddScoped<IBannerService,BannerService> ();
            services.AddScoped<IProductService,ProductService> ();
            services.AddScoped<IFileService, FileService> ();
        }
    }
}
