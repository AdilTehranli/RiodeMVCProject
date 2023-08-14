using System.ComponentModel.DataAnnotations;

namespace RiodeMVCProject.ViewModels.BannerVMs;

public record UpdateBannerVM
{
    public int Id { get; set; }
    [Required]
    public IFormFile BannerImage { get; set; }
    [Required]

    public string Subtitle { get; set; }
    [Required]

    public string Title { get; set; }
}
