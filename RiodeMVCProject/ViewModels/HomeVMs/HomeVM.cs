using RiodeMVCProject.Models;
using System.Collections.ObjectModel;

namespace RiodeMVCProject.ViewModels.HomeVMs
{
    public class HomeVM
    {
        public ICollection<Slider> Sliders { get; set; }
        public ICollection<Banner> Banners { get; set; }
        public ICollection<Product > Products { get; set; }
    }
}
