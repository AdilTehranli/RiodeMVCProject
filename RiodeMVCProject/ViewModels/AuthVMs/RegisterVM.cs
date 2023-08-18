using System.ComponentModel.DataAnnotations;

namespace RiodeMVCProject.ViewModels.AuthVMs;

public record RegisterVM
{
    [Required,EmailAddress]
    public string UsernameOrEmail { get; set; }

    [Required, DataType(DataType.Password)]
    public string Password { get; set; }
}
