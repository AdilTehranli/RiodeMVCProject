using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RiodeMVCProject.Models;

public class AppUser:IdentityUser
{
    [Required]
    public string Fullname { get; set; }
    public DateTime BirthDate { get; set; }
}
