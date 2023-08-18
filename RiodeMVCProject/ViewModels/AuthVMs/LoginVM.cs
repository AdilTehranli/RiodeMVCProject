using System.ComponentModel.DataAnnotations;

namespace RiodeMVCProject.ViewModels.AuthVMs;

public record LoginVM
{
    [Required]
    public string UsernameOrEmail { get; set; }

    [Required, DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    public bool RememberMe { get; set; }

}
