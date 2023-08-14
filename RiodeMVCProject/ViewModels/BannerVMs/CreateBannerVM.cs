using System.ComponentModel.DataAnnotations;

namespace RiodeMVCProject.ViewModels.BannerVMs;

public record CreateBannerVM
{
    [Required]
    public IFormFile BannerImage { get; set; }
    [Required]

    public string Subtitle { get; set; }
    [Required]

    public string Title { get; set; }
}
