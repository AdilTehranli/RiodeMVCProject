using System.ComponentModel.DataAnnotations;

namespace RiodeMVCProject.ViewModels.SliderVMs;

public record CreateSliderVM
{
    public IFormFile SliderImage { get; set; }
    [Required]
    public string SubTitle { get; set; }
    [Required]

    public string Title { get; set; }
    [Required]

    public string DisCount { get; set; }
    [Required]
    public string Description { get; set; }
}
