using System.ComponentModel.DataAnnotations;

namespace RiodeMVCProject.ViewModels.AuthVMs;

public record RegisterVM
{
    [Required]
    public string Username { get; set; }
    [Required, DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required, DataType(DataType.Password)]
    public string Password { get; set; }
    [Required, DataType(DataType.Password), Compare(nameof(Password))]
    public string RepeatPassword { get; set; }
}
