using RiodeMVCProject.Models;

namespace RiodeMVCProject.ViewModels.UserVMs;

public record UserAndRolesVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
}
